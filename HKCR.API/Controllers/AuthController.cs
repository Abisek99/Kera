using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
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

    [HttpPost]
    [Route("/api/v1/auth/register")]
    public async Task<ResponseDto> Register([FromBody] UserRegisterRequestDto model)
    {
        var result = await _authenticationManager.Register(model);
        return result;
    }
}