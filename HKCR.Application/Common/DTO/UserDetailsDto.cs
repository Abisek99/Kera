namespace HKCR.Application.Common.DTO;

public class UserDetailsDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string? RoleUser { get; set; }
    public string? Name { get; set; }
    public string? Id { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsPhoneNumberConfirmed { get; set; }
    public string? DocId { get; set; }
    public string? DocImage { get; set; }
    public string? DocType { get; set; }
}