using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class Component
    {
        public int ComponentID { get; set; }
        public string Category { get; set; }
        public string ComponentName { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }
    }
    public class ComponentModel
    {
        [Required]
        [Display(Name = "Component Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Manufacturer { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Additional Data")]
        public string AdditionalData { get; set; }

        public List<Component> Components { get; set; }

        public int ComponentID { get; set; }

        public ComponentModel()
        {
            Components = new List<Component>()
            {
                new Component {
                    ComponentID = 1 ,
                    ComponentName = "Engine",
                    Manufacturer = "Rolls Royce"
                },
                new Component {
                    ComponentID = 2 ,
                    ComponentName = "Landing Gear",
                    Manufacturer = "Boeing"
                }
            };
        }

    }
}
