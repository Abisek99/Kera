using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HKCR.Infra.Services;

public class AuthenticationService : IAuthentication
{
    private readonly UserManager<AddUser> _userManager;
    private readonly SignInManager<AddUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _dbContext;

    public AuthenticationService(UserManager<AddUser> userManager, SignInManager<AddUser> signInManager,
        IConfiguration configuration, IApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _dbContext = dbContext;
    }

    public async Task<AuthResponseDto> Register(UserRegisterRequestDto model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Email);
        if (userExists != null)
            return new AuthResponseDto() { Status = "Error", Message = "User already exists!", StatusCode = 401 };

        if (string.IsNullOrEmpty(model.RoleUser))
        {
            model.RoleUser = "user";
        }

        AddUser user = new()
        {
            Name = model.Name,
            IsStaff = false,
            Email = model.Email,
            RoleUser = model.RoleUser,
            PhoneNumber = model.PhoneNumber,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new AuthResponseDto
            {
                Status = "Error",
                Message = "User creation failed! Please check user details and try again.",
                StatusCode = 403,
            };

        var oneUser = await _userManager.FindByNameAsync(model.Username);
        return new AuthResponseDto
        {
            Status = "Success",
            Message = "User created successfully!",
            Token = GenerateJwtToken(oneUser),
            UserName = oneUser.UserName,
            StatusCode = 201,
            UserRole = oneUser.RoleUser
        };
    }

    public async Task<AuthResponseDto> Login(UserLoginRequestDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

        if (!result.Succeeded)
            return new AuthResponseDto()
            {
                Message = "User login failed! Please check user details and try again.!",
                Status = "Error"
            };
        var user = await _userManager.FindByNameAsync(model.Username);
        GenerateJwtToken(user);
        return new AuthResponseDto()
        {
            Message = "User logged in!",
            Status = "Success",
            Token = GenerateJwtToken(user),
            StatusCode = 200,
            UserName = user.UserName,
            UserRole = user.RoleUser,
            ID = user.Id
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
            x.EmailConfirmed,
            x.Name,
            x.RoleUser,
            x.Id,
            x.PhoneNumber
        }).ToListAsync();

        var userDetails = from userData in users
            select new UserDetailsDto()
            {
                Email = userData.Email,
                UserName = userData.UserName,
                IsEmailConfirmed = userData.EmailConfirmed,
                Name = userData.Name,
                RoleUser = userData.RoleUser,
                Id = userData.Id,
                PhoneNumber = userData.PhoneNumber
            };
        return userDetails;
    }

    public async Task<UserDetailsDto> GetSingleUser(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var userDetails = new UserDetailsDto()
        {
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name,
            RoleUser = user.RoleUser,
            Id = user.Id,
            IsEmailConfirmed = user.EmailConfirmed,
            PhoneNumber = user.PhoneNumber
        };
        return userDetails;
    }

    // public async Task<UserDetailsDto> GetOneUser(Guid id)
    // {
    //     var userData = await _dbContext.AddUser.FindAsync(id);
    //     var result = new UserDetailsDto()
    //     {
    //         Id = userData!.Id,
    //         Name = userData.Name,
    //         UserName = userData.UserName,
    //         PhoneNumber = userData.PhoneNumber,
    //         Email = userData.Email,
    //         IsEmailConfirmed = userData.EmailConfirmed,
    //         RoleUser = userData.RoleUser
    //     };
    //     return result;
    // }

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