using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMaintain.CoreWebMVC.Models
{
    [Table("EngineTypeDetails")]
    public class EngineType
    {
        [Key]
        public int EnginrTypeID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string AdditionalData { get; set; }
    }

    public class EngineTypeViewModel
    {
        [Required]
        [Display(Name = "Engine Type Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Additional Data")]
        public string AdditionalData { get; set; }   
    }
}
