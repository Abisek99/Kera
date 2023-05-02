using HKCR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.DamageRequest
{
    public class DamageReqDto
    {
        public string? DamageDescription { get; set; }
        public DateTime? DamageDate { get; set; }
        public string? DamageStatus { get; set; }
        public int? RepairBill { get; set; }
        public string? DamagedBy { get; set; }
        public string? AddUserId { get; set; }
        public Guid? RentalId { get; set; }
    }
}