using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EasyMaintain.CoreWebMVC.DataEntities
{
    public class ComponentWork
    {
        public int WorkID { get; set; }
        public string Component { get; set; }
        public string SerialNumber { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public DeliveryDetails Deliverydetails { get; set; }

        public string CreatedDate { get; set; }
        public string Location { get; set; }
    }
}
