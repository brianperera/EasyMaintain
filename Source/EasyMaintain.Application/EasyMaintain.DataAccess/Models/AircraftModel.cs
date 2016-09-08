using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DataAccess.Models
{
    public class AircraftModel
    {
        public int CategoryID;
        public int EngineTypeID;
        public string FlightNumber;

        public int AircraftModelID { get; set; }
        public Category Category { get; set; }
        public string ModelName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public EngineType EngineType { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }




    }
}
