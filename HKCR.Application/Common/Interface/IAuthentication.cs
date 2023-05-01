using HKCR.Application.Common.DTO;

namespace HKCR.Application.Common.Interface;

public interface IAuthentication
{
    Task<AuthResponseDto> Register(UserRegisterRequestDto model);
    Task<AuthResponseDto> Login(UserLoginRequestDto model);
    Task<ResponseDto> Logout();
    Task<IEnumerable<UserDetailsDto>> GetUserDetails();
    Task<UserDetailsDto> GetSingleUser(string userName);
    Task<AuthResponseDto> DeleteUser(string userName);
    Task<AuthResponseDto> ChangePassword(ChangePasswordReqDto model);
}