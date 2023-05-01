using System.ComponentModel.DataAnnotations;

namespace HKCR.Application.Common.DTO;

public class UserRegisterRequestDto
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    public string? PhoneNumber { get; set; }

    public string? RoleUser { get; set; }
    public Guid? DocId { get; set; }
}