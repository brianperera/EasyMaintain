using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyMaintain.DataAccess_v2.Models
{
    public class SparePart
    {
        [Key]
        internal int CategoryID;

        public int SparePartID { get; set; }
        public Category Category { get; set; }
        public string SparePartName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }


    }
}
