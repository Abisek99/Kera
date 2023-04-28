using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Identity;

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

    public Task<ResponseDto> Login(UserLoginRequestDto model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDetailsDto>> GetUserDetails()
    {
        throw new NotImplementedException();
    }
}