using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
    public class AircraftModel : IBusiness
    {
        AircraftModel mAircraftModel;

        public int AircraftModelID { get; set; }
        public Category Category { get; set; }
        public string ModelName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public EngineType EngineType { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }

        // Constructor
        public AircraftModel()
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
            foreach(DataAccess.AircraftModel aircraftModel in dp.GetAircraftModelData())
            {
                AircraftModel _aircraftMod = new AircraftModel();
                _aircraftMod.AircraftModelID = aircraftModel.AircraftModelID;
                _aircraftMod.Category = new Category() { CategoryID = (int)aircraftModel.CategoryID, CategoryName = aircraftModel.Category.CategoryName, AdditionalData = aircraftModel.AdditionalData };
                _aircraftMod.EngineType = new EngineType() { EngineTypeID = (int)aircraftModel.EngineType.EngineTypeID, EngineTypeName = aircraftModel.EngineType.EngineTypeName, ManufacturerID = (int)aircraftModel.ManufacturerID, AdditionalData = aircraftModel.AdditionalData };
                _aircraftMod.Description = aircraftModel.Description;
                _aircraftMod.ModelName = aircraftModel.ModelName;
                _aircraftMod.Manufacturer = new Manufacturer() { ManufacturerID = (int)aircraftModel.ManufacturerID, Name = aircraftModel.ModelName, Description = aircraftModel.Description, AdditionalData = aircraftModel.AdditionalData };
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
            return dp.AddAircraftModel(mAircraftModel.Manufacturer.Name, mAircraftModel.Description, mAircraftModel.AdditionalData, mAircraftModel.Category.CategoryID, mAircraftModel.EngineType.EngineTypeID, mAircraftModel.Manufacturer.ManufacturerID, mAircraftModel.ImagePath);
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
            return dp.UpdateAircraftModel(mAircraftModel.AircraftModelID, mAircraftModel.Manufacturer.Name, mAircraftModel.Description, mAircraftModel.AdditionalData, mAircraftModel.Category.CategoryID, mAircraftModel.EngineType.EngineTypeID, mAircraftModel.Manufacturer.ManufacturerID, mAircraftModel.ImagePath);
        }
    }
}
