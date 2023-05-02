using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.Rental
{
    public class RentalRequestDto
    {
        public DateTime? RentalRequestDate { get; set; }

        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? RentalStatus { get; set; }
        public string? DamageStatus { get; set; }
        public Guid CarID { get; set; }
        public Guid? UserID { get; set; }

        public Guid? StaffId { get; set; }
    }
}