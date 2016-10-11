using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
   public class ComponentWork
    {
        [Key]
        public int WorkID { get; set; }
        public string Component { get; set; }
        public string SerialNumber { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public  DeliveryDetails Deliverydetails { get; set; }
        public string CreatedDate { get; set; }
        public string Location { get; set; }


    }
}
