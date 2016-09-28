using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess_v2.Models
{
    public class ComponentWork
    {
        [Key]
        public int WorkID { get; set; }
        public string Component { get; set; }
        public string SerialNumber { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }

        public int DeliverydetailsId { get; set; }
        public DeliveryDetails Deliverydetails { get; set; }

        public string CreatedDate { get; set; }
        public string Location { get; set; }
    }
}
