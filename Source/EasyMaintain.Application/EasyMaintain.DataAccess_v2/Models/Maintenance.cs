using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMaintain.DataAccess_v2.Models
{
    [Table("Maintenance")]
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
        public List<MaintenanceChecks> CheckItems { get; set; }
        public List<Crew> CrewMembers { get; set; }

    }
}
