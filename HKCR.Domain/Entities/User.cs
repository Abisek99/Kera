using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HKCR.Domain.Shared;

namespace HKCR.Domain.Entities;

public class User : BaseEntity
{

    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserRole Role { get; set; } = UserRole.User;


    [ForeignKey("Document")] public Guid? DocId { get; set; }
    public virtual Document Document { get; set; }
}