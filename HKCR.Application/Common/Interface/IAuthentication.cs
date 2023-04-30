using HKCR.Application.Common.DTO;

namespace HKCR.Application.Common.Interface;

public interface IAuthentication
{
    Task<ResponseDto> Register(UserRegisterRequestDto model);
    Task<ResponseDto> Login(UserLoginRequestDto model);
    Task<ResponseDto> Logout();
    Task<IEnumerable<UserDetailsDto>> GetUserDetails();
}