namespace HKCR.Application.Common.DTO;

public class AuthResponseDto
{
    public string? Status { get; set; }
    public string? Message { get; set; }
    public string? UserName { get; set; }
    public string? Token { get; set; }
    public int StatusCode { get; set; }
    public string? UserRole { get; set; }
    public string? ID { get; set; }
}