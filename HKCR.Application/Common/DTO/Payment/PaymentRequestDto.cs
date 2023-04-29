using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.Payment
{
    public class PaymentRequestDto
    {
        public string PaymentType { get; set; }
        public int PaymentTotal { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }


        public Guid RentalID { get; set; }



        public Guid OfferID { get; set; }
    }
}
