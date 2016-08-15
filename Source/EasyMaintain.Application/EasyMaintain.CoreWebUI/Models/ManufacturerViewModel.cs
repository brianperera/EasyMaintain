using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMaintain.CoreWebUI.Models
{
    [Table("ManufacturerDetails")]
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
    }

    public class ManufacturerViewModel
    {
        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Additional Data")]
        public string AdditionalData { get; set; }   
    }
}
