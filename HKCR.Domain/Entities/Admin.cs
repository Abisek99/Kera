using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Admin
    {
        public Guid AdminID { get; set; } = new Guid();
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
        public string AdminContact { get; set;}
    }
}