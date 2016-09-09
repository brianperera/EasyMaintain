using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess.Models
{
    public class Manufacturer
    {
        
        [Key]
        public string ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
        public string ManufacturerName { get; internal set; }
    }
}
