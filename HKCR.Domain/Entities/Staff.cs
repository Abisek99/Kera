using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Staff
    {
        public Guid StaffID { get; set; } = new Guid();
        public string StaffEmail { get; set; }
        public string StaffPassword { get; set; }
    }
}
