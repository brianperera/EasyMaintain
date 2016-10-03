using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
   public class Crew
    {
        [Key]
        public int CrewID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }


    }
}
