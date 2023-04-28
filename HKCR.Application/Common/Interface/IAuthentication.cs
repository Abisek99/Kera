using HKCR.Application.Common.DTO;

namespace HKCR.Application.Common.Interface;

public interface IAuthentication
{
    Task<ResponseDto> Register(UserRegisterRequestDto model);
    Task<ResponseDto> Login(UserLoginRequestDto model);
    Task<IEnumerable<UserDetailsDto>> GetUserDetails();
}