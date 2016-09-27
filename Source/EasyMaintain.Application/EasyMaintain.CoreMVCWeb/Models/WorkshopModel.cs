using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class Workshop
    {
        public int WorkshopID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
    public class WorkshopModel
    {
        [Required]
        [Display(Name = "Workshop Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public List<Workshop> Workshops { get; set; }

        public int WorkshopID { get; set; }

        public WorkshopModel()
        {
            Workshops = new List<Workshop>()
            {
                new Workshop {
                    WorkshopID = 1 ,
                    Name = "Engine Shop",
                    Location = "Folrida"
                },
                new Workshop {
                    WorkshopID = 2 ,
                    Name = "Electronics Management",
                    Location = "California"
                },
                new Workshop {
                    WorkshopID = 3 ,
                    Name = "Paint Shop",
                    Location = "Detroit"
                },
                new Workshop {
                    WorkshopID = 4 ,
                    Name = "Custom Works",
                    Location = "Michigan"
                }
                
            };
        }
    }
}
