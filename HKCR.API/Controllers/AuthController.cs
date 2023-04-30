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

    [HttpPost]
    [Route("/api/v1/auth/register")]
    public async Task<ResponseDto> Register([FromBody] UserRegisterRequestDto model)
    {
        var result = await _authenticationManager.Register(model);
        return result;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/api/v1/auth/login")]
    public async Task<ResponseDto> Login([FromBody] UserLoginRequestDto user)
    {
        var result = await _authenticationManager.Login(user);
        return result;
    }

    [HttpGet]
    [Route("/api/v1/auth/logout")]
    public async Task<ResponseDto> Logout()
    {
        var result = await _authenticationManager.Logout();
        return result;
    }
}