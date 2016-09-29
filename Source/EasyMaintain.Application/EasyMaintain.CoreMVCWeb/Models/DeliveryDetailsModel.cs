using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;

namespace EasyMaintain.CoreWebMVC.Models
{

    //public class DeliveryDetails
    //{
    //    public string DeliveryDate { get; set; }
    //    public string DeliveryMethod { get; set; }
    //    public string PersonInCharge { get; set; }
    //    public string AddressLine1 { get; set; }
    //    public string AddressLine2 { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string AddtionalNotes { get; set; }
    //}

    public class DeliveryDetailsModel
    {
        [Required]
        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }
        public List<string> DeliveryMethods { get; set; }
        public string DeliveryMethod { get; set; }

        public string PersonInCharge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddtionalNotes { get; set; }

        public DeliveryDetailsModel() {
            DeliveryMethods = new List<string>();
            DeliveryMethods.Add("Pick Up");
            DeliveryMethods.Add("USPS");
            DeliveryMethods.Add("DHL");
        }
    }
}
