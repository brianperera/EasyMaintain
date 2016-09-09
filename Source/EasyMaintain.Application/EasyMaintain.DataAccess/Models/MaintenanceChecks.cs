using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess.Models
{
   public class MaintenanceChecks
    {
        [Key]
        public string Description { get; set; }
        public bool status { get; set; }
    }
}
