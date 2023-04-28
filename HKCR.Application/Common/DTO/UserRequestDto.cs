using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO;

public abstract class UserRequestDto
{
    // public DateTime JoinDate { get; set; }
    // public string Designation { get; set; }
    // public float Salary { get; set; }
    // public int DepartmentId { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserRole Role { get; set; }
}