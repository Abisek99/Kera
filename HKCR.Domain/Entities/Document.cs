using HKCR.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Document
    {
        public Guid DocID { get; set; } = new Guid();
        public string DocType { get; set; }
        public string DocImage { get; set; }
        public ICollection<AddUser> AddUsers { get; set; }
    }
}