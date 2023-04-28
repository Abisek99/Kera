using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO;

public class UserResponseDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserRole Role { get; set; }
}
