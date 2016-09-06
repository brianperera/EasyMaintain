using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyMaintain.WebUI.Models
{
    [Table("ComponentWork")]
    public class ComponentWork
    {
        [Key]
        public int WorkID { get; set; }
        public string Component { get; set; }
        public string SerialNumber { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public string DeliveryDate { get; set; }
        public string CreatedDate { get; set; }
        public string Location { get; set; }
    }

    public class ComponentWorkModel
    {
        [Required]
        [Display(Name = "Component Name")]
        public string ComponentName { get; set; }

        [Required]
        [Display(Name = "Work Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Workshop")]
        public string WorkshopLocation { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }

        public static int CurrentID { get; set; }

        public List<string> Workshops { get; set; }


        public List<ComponentWork> ComponentWorkOrders { get; set; }

        public ComponentWorkModel() {
            ComponentWorkOrders = new List<ComponentWork> {
                new ComponentWork
                {
                    WorkID = 1,
                    Component = "Trubine",
                    DeliveryDate = "21/09/2016",
                    Location = "Detroit",
                    SerialNumber = "101020"
                }
            };
            Workshops = new List<string>();
            Workshops.Add("Folrida");
            Workshops.Add("California");
            Workshops.Add("Detroit");
            Workshops.Add("Michigan");

            DateTime dateTime = DateTime.UtcNow.Date;
            CreatedDate = dateTime.ToString("dd/MM/yyyy");
        }


    }
}