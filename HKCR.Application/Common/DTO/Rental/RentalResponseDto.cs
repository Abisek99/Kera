using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.Rental
{
    public class RentalResponseDto
    {
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string RentalStatus { get; set; }
        public string DamageStatus { get; set; }
        public Guid CarID { get; set; }
        public Guid StaffID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
