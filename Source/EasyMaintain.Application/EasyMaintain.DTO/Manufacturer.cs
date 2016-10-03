using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
   public class Manufacturer
    {
        [Key]
        public string ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
    }
}
