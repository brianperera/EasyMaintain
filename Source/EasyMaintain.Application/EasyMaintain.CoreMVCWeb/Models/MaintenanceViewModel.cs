using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMaintain.CoreWebMVC.Utility;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;

namespace EasyMaintain.CoreWebMVC.Models
{
    //[Table("MaintenanceChecks")]
    //public class Check
    //{
    //    [Key]
    //    public string Description { get; set; }
    //    public bool status { get; set; }
    //}


    //[Table("EngineType")]
    //public class Maintenance
    //{
    //    [Key]
    //    public int WorkID { get; set; }
    //    public string FlightModel { get; set; }
    //    public string FlightNumber { get; set; }
    //    public string Description { get; set; }
    //    public string StartDate { get; set; }
    //    public string CompletionDate { get; set; }
    //    public string Location { get; set; }
    //    public List<Check> CheckItems { get; set; }
    //    public List<Crew> CrewMembers { get; set; }
    //}
    public class MaintenanceViewModel : UserDataModel
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

        public WorkshopModel Workshops { get; set; }

        public List<MaintenanceChecks> CheckItems { get; set; }

        public List<Crew> CrewMembers { get; set; }

        public List<Maintenance> MaintenanceOrders { get; set; }

        public string ActiveTab { get; set; }
        public int SelectedMemberIndex { get; set; } = -1 ;

        public AircraftModelModel AircraftModelModelObj { get; set; }
        public MaintenanceCheckViewModel MaintenanceCheckViewModelObj { get; set; }

        public CrewViewModel CrewViewModelObj { get; set; }

        public Token token { get; set; }

        public MaintenanceViewModel()
        {
            Workshops = new WorkshopModel(); 
            MaintenanceOrders = new List<Maintenance> {
                new Maintenance
                {
                    WorkID = 1,
                    FlightModel = "Trubine",
                    StartDate = "21/09/2016",
                    Location = "Detroit",
                    CheckItems = new  List<MaintenanceChecks>(),
                    CrewMembers = new List<Crew>()                    
                    
                }
            };
            SessionUtility.CurrentMaintenanceID = 1;



            DateTime dateTime = DateTime.UtcNow.Date;
            StartDate = dateTime.ToString("dd/MM/yyyy");

            CheckItems = new List<MaintenanceChecks>();
            CheckItems.Add(new MaintenanceChecks() {Description ="Check Left Rudder" });

            CrewMembers = new List<Crew>();
            CrewMembers.Add(new Crew() { Name = "John",Designation = "Technician"});
        }


    }
}
