using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{

    public class DeliveryDetails
    {
        public string DeliveryDate { get; set; }
        public List<string> DeliveryMethod { get; set; }
        public string PersonInCharge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddtionalNotes { get; set; }


    }
    public class DeliveryDetailsModel
    {
        [Required]
        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }
        public List<string> DeliveryMethod { get; set; }
        public string PersonInCharge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddtionalNotes { get; set; }

        DeliveryDetailsModel() {

            DeliveryMethod = new List<string>();
            DeliveryMethod.Add("Pick Up");
            DeliveryMethod.Add("USPS");
            DeliveryMethod.Add("DHL");
        }
    }
}
