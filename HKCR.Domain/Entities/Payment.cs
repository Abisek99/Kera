using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentID { get; set; } = new Guid();
        public string PaymentType { get; set;}
        public int PaymentTotal { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set;}

        [ForeignKey("Rental")]
        public Guid RentalID { get; set; }
        public virtual RentalRequest RentalRequest { get; set; }

        [ForeignKey("Offers")]
        public Guid OfferID { get; set; }
        public virtual Offers Offers { get; set; }

    }
}
