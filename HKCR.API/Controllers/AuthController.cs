using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthentication _authenticationManager;

    public AuthController(IAuthentication authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }

    [HttpGet]
    [Route("/api/v1/auth/getUserDetails")]
    public async Task<IEnumerable<UserDetailsDto>> GetUserDetails()
    {
        var result = await _authenticationManager.GetUserDetails();
        return result;
    }

    [HttpGet]
    [Route("/api/v1/auth/getSingleUser")]
    public async Task<UserDetailsDto> GetSingleUser(string username)
    {
        var result = await _authenticationManager.GetSingleUser(username);
        return result;
    }

    [HttpPost]
    [Route("/api/v1/auth/register")]
    public async Task<AuthResponseDto> Register([FromBody] UserRegisterRequestDto model)
    {
        var result = await _authenticationManager.Register(model);
        return result;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/api/v1/auth/login")]
    public async Task<AuthResponseDto> Login([FromBody] UserLoginRequestDto user)
    {
        var result = await _authenticationManager.Login(user);
        return result;
    }

    [HttpPatch]
    [Route("/api/v1/auth/changePassword")]
    public async Task<AuthResponseDto> ChangePassword([FromBody] ChangePasswordReqDto model)
    {
        var result = await _authenticationManager.ChangePassword(model);
        return result;
    }

    [HttpGet]
    [Route("/api/v1/auth/logout")]
    public async Task<ResponseDto> Logout()
    {
        var result = await _authenticationManager.Logout();
        return result;
    }

    [HttpDelete]
    [Route("/api/v1/auth/deleteUser")]
    public async Task<AuthResponseDto> DeleteUser(string username)
    {
        var result = await _authenticationManager.DeleteUser(username);
        return result;
    }
}