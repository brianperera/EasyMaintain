using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class Inventory
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string AdditionalNotes { get; set; }
        public List<string> PartsList { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentMethod { get; set; }
        public DeliveryDetails Deliverydetails { get; set; }


    }
    public class InventoryViewModel
    {
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }


        [Required]
        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        public DeliveryDetails Deliverydetails { get; set; }

        public List<string> PartsList { get; set; }

        public List<string> PaymentMethods { get; set; }

        public List<Inventory> InventoryOrders { get; set; }

        public InventoryViewModel()
        {

            InventoryOrders = new List<Inventory> {
                new Inventory
                {
                    InvoiceNumber = 1,
                    CustomerName = "Trune",
                    CompanyName = "Cessna",
                    PaymentMethod = "Card Payment",
                    PartsList = new List<string>() {"Rudder","Wheels","Lights"},
                    Deliverydetails = new DeliveryDetails() {DeliveryDate = "21/07/2016" } 
                }
            };

            PartsList = new List<string>();

            PaymentMethods = new List<string>();
            PaymentMethods.Add("Cash On Delivery");
            PaymentMethods.Add("Card Payment");
            PaymentMethods.Add("Payment Transfer");
        }

    }
}
