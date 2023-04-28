using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; } = new Guid();
        public string CustomerDiscount { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
