﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Application.Common.DTO.DamageRequest
{
    public class DamageResDto
    {

        public string DamageDescription { get; set; }
        public DateTime DamageDate { get; set; }
        public string DamageStatus { get; set; }
        public int RepairBill { get; set; }

        public Guid CustomerId { get; set; }

        public Guid RentalId { get; set; }
    }
}
