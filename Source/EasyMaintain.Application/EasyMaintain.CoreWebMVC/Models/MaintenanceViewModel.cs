using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMaintain.CoreWebMVC.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    [Table("MaintenanceChecks")]
    public class Check
    {
        [Key]
        public string Description { get; set; }
        public bool status { get; set; }
    }

    public class Crew
    {
        [Key]
        public string Name { get; set; }
        public string Designation { get; set; }
    }

    [Table("EngineType")]
    public class Maintenance
    {
        [Key]
        public int WorkID { get; set; }
        public string FlightModel { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string CompletionDate { get; set; }
        public string Location { get; set; }
        public List<Check> CheckItems { get; set; }
        public List<Crew> CrewMembers { get; set; }


    }
    public class MaintenanceViewModel
    {
        [Required]
        [Display(Name = "Flight Model")]
        public string FlightModel { get; set; }

        [Required]
        [Display(Name = "Work Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Workshop")]
        public string WorkshopLocation { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = "Completion Date")]
        public string CompletionDate { get; set; }

        [Required]
        [Display(Name = "Completion Date")]
        public int WorkID { get; set; }

        public List<string> Workshops { get; set; }

        public List<Check> CheckItems { get; set; }

        public List<Crew> CrewMembers { get; set; }

        public List<Maintenance> MaintenanceOrders { get; set; }

        public string ActiveTab { get; set; }

        public MaintenanceViewModel()
        {
            MaintenanceOrders = new List<Maintenance> {
                new Maintenance
                {
                    WorkID = 1,
                    FlightModel = "Trubine",
                    StartDate = "21/09/2016",
                    Location = "Detroit",
                    CheckItems = new  List<Check>(),
                    CrewMembers = new List<Crew>()                    
                    
                }
            };
            SessionUtility.CurrentMaintenanceID = 1;

            Workshops = new List<string>();
            Workshops.Add("Folrida");
            Workshops.Add("California");
            Workshops.Add("Detroit");
            Workshops.Add("Michigan");

            DateTime dateTime = DateTime.UtcNow.Date;
            StartDate = dateTime.ToString("dd/MM/yyyy");

            CheckItems = new List<Check>();
            CheckItems.Add(new Check() {Description ="Check Left Rudder" });

            CrewMembers = new List<Crew>();
            CrewMembers.Add(new Crew() { Name = "John",Designation = "Technician"});
        }


    }
}
