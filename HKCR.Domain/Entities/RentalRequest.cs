using System.ComponentModel.DataAnnotations.Schema;

namespace HKCR.Domain.Entities
{
    public class RentalRequest
    {
        public Guid? RentalId { get; set; } = Guid.NewGuid();
        public DateTime? RentalRequestDate { get; set; }
        public string? RentalStatus { get; set; } = "pending";

        public string? DamageStatus { get; set; }
        public DateTime? ReturnDate { get; set; }

        public DateTime? RentalDate { get; set; }
        [ForeignKey("Cars")] public Guid? CarID { get; set; }
        public virtual Cars? Car { get; set; }

        [ForeignKey("AddUser")] public string? AddUserId { get; set; }
        public virtual AddUser AddUser { get; set; }
    }
}