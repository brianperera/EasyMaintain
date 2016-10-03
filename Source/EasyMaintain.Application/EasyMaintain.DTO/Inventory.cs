using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
  public  class Inventory
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string AdditionalNotes { get; set; }
        public List<string> PartsList { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentNotes { get; set; }
        public string BillingAddress { get; set; }
        public string BillingName { get; set; }
        public bool OrderType { get; set; } //NormalOrder = false , //ReStockOrder = True 
        public DeliveryDetails Deliverydetails { get; set; }

    }
}
