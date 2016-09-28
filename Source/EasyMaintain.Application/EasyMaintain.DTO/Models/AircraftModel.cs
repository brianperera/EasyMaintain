using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.DTO
{
    public class AircraftModel
    {
        public int AircraftModelID { get; set; }
        public string Category { get; set; }
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public string EngineType { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }
    }
}
