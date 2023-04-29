using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HKCR.Infra.Services;

public class AuthenticationService : IAuthentication
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

        return new ResponseDto { Status = "Success", Message = "User created successfully!" };
    }

    public async Task<ResponseDto> Login(UserLoginRequestDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

        if (result.Succeeded)
        {
            return new ResponseDto()
            {
                Message = "User logged in!",
                Status = "Success"
            };
        }

        return new ResponseDto()
        {
            Message = "User login failed! Please check user details and try again.!",
            Status = "Error"
        };
        

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
        // var userDetails = from userData in users
        //     select new UserDetailsDto()
        //     {
        //         Email = userData.Email,
        //         UserName = userData.UserName,
        //         IsEmailConfirmed = userData.EmailConfirmed
        //     };

        //OR
        var userDatas = new List<UserDetailsDto>();
        foreach (var item in users)
        {
            userDatas.Add(new UserDetailsDto()
            {
                Email = item.Email,
                UserName = item.UserName,
                IsEmailConfirmed = item.EmailConfirmed
            });
        }

        return userDatas;
    }
}