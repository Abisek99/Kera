using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HKCR.Infra.Services;

public class AuthenticationService : IAuthentication
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<ResponseDto> Register(UserRegisterRequestDto model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Email);
        if (userExists != null)
            return new ResponseDto { Status = "Error", Message = "User already exists!" };

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new ResponseDto
            {
                Status = "Error", Message = "User creation failed! Please check user details and try again."
            };

        var oneUser = await _userManager.FindByNameAsync(model.Username);
        return new ResponseDto
            { Status = "Success", Message = "User created successfully!", Token = GenerateJwtToken(oneUser) };
    }

    public async Task<ResponseDto> Login(UserLoginRequestDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            GenerateJwtToken(user);
            return new ResponseDto()
            {
                Message = "User logged in!", Status = "Success", Token = GenerateJwtToken(user)
            };
        }

        return new ResponseDto()
        {
            Message = "User login failed! Please check user details and try again.!",
            Status = "Error"
        };
    }

    public async Task<ResponseDto> Logout()
    {
        await _signInManager.SignOutAsync();
        var response = new ResponseDto()
        {
            Message = "Log out Successful",
            Status = "Success"
        };
        return response;
    }

    public async Task<IEnumerable<UserDetailsDto>> GetUserDetails()
    {
        var users = await _userManager.Users.Select(x => new
        {
            x.Email,
            x.UserName,
            x.EmailConfirmed
        }).ToListAsync();

        //either
        var userDetails = from userData in users
            select new UserDetailsDto()
            {
                Email = userData.Email,
                UserName = userData.UserName,
                IsEmailConfirmed = userData.EmailConfirmed
            };

        //OR
        // var userDatas = new List<UserDetailsDto>();
        // foreach (var item in users)
        // {
        //     userDatas.Add(new UserDetailsDto()
        //     {
        //         Email = item.Email,
        //         UserName = item.UserName,
        //         IsEmailConfirmed = item.EmailConfirmed
        //     });
        // }
        //
        // return userDatas;
        return userDetails;
    }

    // JWT
    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtSecret = _configuration.GetConnectionString("jwtSecret");
        var key = Encoding.ASCII.GetBytes(jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        Console.WriteLine(tokenHandler.WriteToken(token));
        return tokenHandler.WriteToken(token);

        // return Task.FromResult(new ResponseDto
        // {
        //     Token = tokenHandler.WriteToken(token)
        // });
    }
}