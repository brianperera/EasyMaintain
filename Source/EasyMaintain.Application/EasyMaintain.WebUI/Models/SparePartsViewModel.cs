using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.WebUI.Models
{
    public class SparePartsViewModel
    {
        [Required]
        [Display(Name = "Spare Part Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Spare Part Name")]
        public string Description { get; set; }   
    }
}
