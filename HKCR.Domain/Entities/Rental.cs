using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Rental
    {
        public Guid RentalID { get; set; } = new Guid();
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string RentalStatus { get; set; }
        public string DamageStatus { get; set; }

        [ForeignKey("Cars")]
        public Guid CarID { get; set; }
        public virtual Cars Car { get; set; }

        [ForeignKey("Saff")]
        public Guid StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
