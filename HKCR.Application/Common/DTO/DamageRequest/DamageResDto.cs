using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKCR.Application.Common.DTO.Rent;
using HKCR.Application.Common.DTO.Rental;
using HKCR.Domain.Entities;

namespace HKCR.Application.Common.DTO.DamageRequest
{
    public class DamageResDto
    {
        public Guid? DamageID { get; set; }
        public string? DamageDescription { get; set; }
        public DateTime? DamageDate { get; set; }
        public string? DamageStatus { get; set; }
        public int? RepairBill { get; set; }

        public string? DamagedBy { get; set; }
        public string? AcceptedBy { get; set; }
    }
}