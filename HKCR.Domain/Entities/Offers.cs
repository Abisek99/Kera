using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCR.Domain.Entities
{
    public class Offers
    {
        public Guid OfferID { get; set; } = new Guid();
        public string OfferName { get; set; }
        public string OfferType { get; set;}
        public string OfferAmount { get; set;}

    }
}
