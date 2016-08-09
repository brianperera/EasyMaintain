using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public class AircraftModel : IBusiness
    {
        AircraftModel mAircraftModel;

        public int AircraftModelID { get; set; }
        public string Category { get; set; }
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public string EngineType { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }

        public AircraftModel()
        { 
           //TODO
        }

        public object GetData()
        {   
            //TODO
            return new List<AircraftModel>();
        }

        public int Save(object aircraftModel)
        {
            //TODO
            this.mAircraftModel = aircraftModel as AircraftModel;
            return -1;
        }

        public int Insert(object aircraftModel)
        {
            //TODO
            this.mAircraftModel = aircraftModel as AircraftModel;
            return -1;
        }

        public void DeleteOne(object aircraftModel)
        {
            //TODO
            this.mAircraftModel = aircraftModel as AircraftModel;
        }
    }
}
