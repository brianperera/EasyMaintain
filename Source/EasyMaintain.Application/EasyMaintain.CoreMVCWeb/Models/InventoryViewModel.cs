using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;

namespace EasyMaintain.CoreWebMVC.Models
{
    //public class Inventory
    //{
    //    public string CustomerName { get; set; }
    //    public string CompanyName { get; set; }
    //    public string AdditionalNotes { get; set; }
    //    public List<string> PartsList { get; set; }
    //    public int InvoiceNumber { get; set; }
    //    public string PaymentMethod { get; set; }
    //    public string PaymentNotes { get; set; }
    //    public string BillingAddress { get; set; }
    //    public string BillingName { get; set; }
    //    public bool OrderType { get; set; } //NormalOrder = false , //ReStockOrder = True 
    //    public DeliveryDetails Deliverydetails { get; set; }
    //}

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

        public DeliveryDetailsModel Deliverydetailsmodel { get; set; }

        public List<string> PartsList  { get; set; }

        public List<string> PaymentMethods { get; set; }

        public string PaymentMethod { get; set; }
        public string PaymentNotes { get; set; }
        public string BillingAddress { get; set; }
        public string BillingName { get; set; }

        public List<string> DeliveryMethods { get; set; }
        public List<Inventory> InventoryOrders { get; set; }
        public List<Inventory> RestockOrders { get; set; }
        public string ActiveTab { get; set; }
        public SparePartsViewModel SparePartsViewModel { get; set; }


        public InventoryViewModel()
        {
            SparePartsViewModel = new SparePartsViewModel();
            Deliverydetailsmodel = new DeliveryDetailsModel();
            Deliverydetails = new DeliveryDetails();
            InventoryOrders = new List<Inventory> {
                new Inventory
                {
                    InvoiceNumber = 1,
                    CustomerName = "TruneOrders",
                    CompanyName = "CessnaOrders",
                    PaymentMethod = "Card Payment",
                    PartsList = new List<string>() {"Rudder","Wheels","Lights"},
                    Deliverydetails = new DeliveryDetails() {DeliveryDate = "21/07/2016" } 
                }
            };

            RestockOrders = new List<Inventory> {
                new Inventory
                {
                    InvoiceNumber = 1,
                    CustomerName = "TruneStocks",
                    CompanyName = "CessnaStocks",
                    PaymentMethod = "Card Payment",
                    PartsList = new List<string>() {"Rudder","Wheels","Lights"},
                    Deliverydetails = new DeliveryDetails() {DeliveryDate = "21/07/2016" }
                }
            };

            PartsList = new List<string>();

            DeliveryMethods = new List<string>();
            DeliveryMethods.Add("Pick Up");
            DeliveryMethods.Add("USPS");
            DeliveryMethods.Add("DHL");

            PaymentMethods = new List<string>();
            PaymentMethods.Add("Cash On Delivery");
            PaymentMethods.Add("Card Payment");
            PaymentMethods.Add("Payment Transfer");
        }

    }
}
