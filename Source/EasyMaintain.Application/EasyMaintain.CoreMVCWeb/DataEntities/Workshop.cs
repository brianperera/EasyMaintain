using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.DataEntities
{
    public class Workshop
    {
        public int WorkshopID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
