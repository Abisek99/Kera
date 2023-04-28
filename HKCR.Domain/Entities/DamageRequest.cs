using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class DamageRequest
    {
        public Guid DamageId { get; set; }= new Guid();
        public string DamageDescription { get; set; }
        public DateTime DamageDate { get; set; }
        public string DamageStatus { get; set;}
        public int RepairBill { get; set;}

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // [ForeignKey("Rental")]
        // public Guid RentalId { get; set; }
        // public virtual Rental Rental { get; set; }
    }
}
