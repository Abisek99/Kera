using System.ComponentModel.DataAnnotations.Schema;

namespace HKCR.Domain.Entities;

public class Rent
{
    public Guid RentId { get; set; } = new Guid();
    public DateTime? RentalDate { get; set; }
    public string? DamageStatus { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? RentalStatus { get; set; }
    public DateTime? ApprovedDate { get; set; }


    [ForeignKey("RentalRequest")] public Guid? RentalId { get; set; }
    public virtual RentalRequest RentalRequest { get; set; }

    [ForeignKey("AddUser")] public string? ApprovedBy { get; set; }
    public virtual AddUser AddUser { get; set; }




}