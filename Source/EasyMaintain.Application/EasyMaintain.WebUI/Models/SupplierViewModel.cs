using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMaintain.WebUI.Models
{

    [Table("SupplierDetails")]  
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalData { get; set; }   
    }


    public class SupplierViewModel
    {
        [Required]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Contact Details")]
        public string ContactDetails { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Additional Data")]
        public string AdditionalData { get; set; }

        private List<Supplier> suppliersList = new List<Supplier>();

        [Display(Name = "Suppliers List")]
        public List<Supplier> SuppliersList
        {
            get { return suppliersList; }
        }

    }
}
