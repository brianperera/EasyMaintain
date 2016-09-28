using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.DTO;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class MaintenanceCheckViewModel
    {

        public int MaintenanceCheckID { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }
        public int currentIndex { get; set; }

        public List<MaintenanceChecks> Checks { get; set; }

        public MaintenanceCheckViewModel()
        {
            Checks = new List<MaintenanceChecks>();
            Checks.Add(new MaintenanceChecks() { MaintenanceCheckID = 1 , Description = "Check Landing Gear Hydraulics" });
        }
    }
}
