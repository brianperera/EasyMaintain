using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess.Models
{
    public class Supplier
    {
       public  string SupplierName;
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalData { get; set; }
    }
}
