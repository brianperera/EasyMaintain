using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
    public class DeliveryDetails
    {
        public string DeliveryDate { get; set; }
        public string DeliveryMethod { get; set; }
        public string PersonInCharge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddtionalNotes { get; set; }

    }
}
