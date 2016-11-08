using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;
using EasyMaintain.DTO;

namespace EasyMaintain.Business
{
   public class AircraftModelLogic
    {
        AircraftModel mAircraftModel;
        public AircraftModelLogic()
        {
        }
        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            List<AircraftModel> result = new List<AircraftModel>();

            DataProvidor dp = new DataProvidor();
            foreach (DTO.AircraftModel aircraftModel in dp.GetAircraftModelData())
            {
                AircraftModel _aircraftMod = new AircraftModel();
                _aircraftMod.AircraftModelID = aircraftModel.AircraftModelID;
                _aircraftMod.Category = aircraftModel.Category;
                _aircraftMod.EngineType = aircraftModel.EngineType;
                _aircraftMod.Description = aircraftModel.Description;
                _aircraftMod.ModelName = aircraftModel.ModelName;
                _aircraftMod.Manufacturer = aircraftModel.Manufacturer;
                _aircraftMod.ImagePath = aircraftModel.ImagePath;
                _aircraftMod.AdditionalData = aircraftModel.AdditionalData;

                result.Add(_aircraftMod);
            }

            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="aircraftModel"></param>
        /// <returns></returns>
        public int Save(object aircraftModel)
        {
            //TODO
            //this.mAircraftModel = aircraftModel as AircraftModel;
            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="aircraftModel"></param>
        /// <returns></returns>
        public int Insert(object aircraftModel)
        {
            this.mAircraftModel = aircraftModel as AircraftModel;
            DataProvidor dp = new DataProvidor();
            return dp.AddAircraftModel(mAircraftModel.ModelName, mAircraftModel.Description, mAircraftModel.AdditionalData, mAircraftModel.Category, mAircraftModel.Manufacturer, mAircraftModel.ImagePath);
        }

        /// <summary>
        /// Delete One record
        /// </summary>
        /// <param name="aircraftModel"></param>
        public void DeleteOne(object aircraftModel)
        {
            this.mAircraftModel = aircraftModel as AircraftModel;
            DataProvidor dp = new DataProvidor();

            dp.DeleteAircraftModel(mAircraftModel.AircraftModelID);

        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="aircraftModel"></param>
        /// <returns></returns>
        public bool UpdateOne(object aircraftModel)
        {
            this.mAircraftModel = aircraftModel as AircraftModel;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateAircraftModel(mAircraftModel.AircraftModelID, mAircraftModel.Manufacturer, mAircraftModel.Description, mAircraftModel.AdditionalData, mAircraftModel.Category, mAircraftModel.EngineType, mAircraftModel.Manufacturer, mAircraftModel.ImagePath);
        }
        public AircraftModel Find(object AircraftModelID)
        {
            List<AircraftModel> result = new List<AircraftModel>();
            return result
                .Where(e => e.AircraftModelID.Equals(AircraftModelID))
                .SingleOrDefault();
        }
    }
}
