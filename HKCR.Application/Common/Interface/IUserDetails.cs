using HKCR.Application.Common.DTO;

namespace HKCR.Application.Common.Interface;

public interface IUserDetails
{
    Task<List<UserResponseDto>> GetAllUserAsync();
    Task<List<UserResponseDto>> GetAllUser();
    Task<UserResponseDto> AddUserDetails(UserRequestDto user);
}