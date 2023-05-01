using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace HKCR.Domain.Entities;

public class AddUser : IdentityUser
{
    public string? Name { get; set; }
    public bool? IsStaff { get; set; } = false;
    public string? RoleUser { get; set; } = "user";

    public string? Profile { get; set; } = "/public/images/uploads/user.jpg";

    [ForeignKey("Document")] public Guid? DocId { get; set; }
    public virtual Document Document { get; set; }
}