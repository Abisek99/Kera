using System.ComponentModel.DataAnnotations.Schema;

namespace HKCR.Domain.Entities
{
    public class DamageRequest
    {
        public Guid? DamageId { get; set; } = Guid.NewGuid();
        public string? DamageDescription { get; set; }
        public DateTime? DamageDate { get; set; }
        public string? DamageStatus { get; set; }
        public int? RepairBill { get; set; } = 1000;
        public string? DamagedBy { get; set; }

        // Staff User ID
        [ForeignKey("AddUser")] public string? AddUserId { get; set; }
        public virtual AddUser? AddUser { get; set; }

        // User who damaged car will be in Rental Request Table
        [ForeignKey("RentalRequest")] public Guid? RentalId { get; set; }
        public virtual RentalRequest? RentalRequest { get; set; }
    }
}