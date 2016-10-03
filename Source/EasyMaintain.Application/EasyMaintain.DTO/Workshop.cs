using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
   public class Workshop
    {
        [Key]
        public int WorkshopID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
