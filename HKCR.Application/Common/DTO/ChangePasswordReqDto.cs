using System.ComponentModel.DataAnnotations;

namespace HKCR.Application.Common.DTO;

public class ChangePasswordReqDto
{
    [Required(ErrorMessage = "UserName is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Current Password is required")]
    public string? CurrentPassword { get; set; }

    [Required(ErrorMessage = "New Password is required")]
    public string? NewPassword { get; set; }
}