using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.Payment
{
    public class PaymentResponseDto
    {
        public string PaymentType { get; set; }
        public int PaymentTotal { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        
        public Guid RentalID { get; set; }
        

        
        public Guid OfferID { get; set; }
        
    }
}
