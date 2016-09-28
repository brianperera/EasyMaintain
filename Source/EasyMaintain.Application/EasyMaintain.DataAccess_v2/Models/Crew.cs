using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess_v2.Models
{
   public class Crew
    {
        [Key]
        public int CrewID { get; set; }
        public string Name { get; set; }
        public string Designation { get;internal set; }

    }
}
