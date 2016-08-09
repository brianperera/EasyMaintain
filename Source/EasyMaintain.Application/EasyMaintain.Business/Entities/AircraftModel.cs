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

        public AircraftModel()
        { 

        }

        public object GetData()
        {
            List<AircraftModel> result = new List<AircraftModel>();

            DataProvidor dp = new DataProvidor();
            foreach(DataAccess.AircraftModel aircraftModel in dp.GetAircraftModelData())
            {
                AircraftModel aircraftMod = new AircraftModel();
                aircraftMod.AircraftModelID = aircraftModel.AircraftModelID;
                aircraftMod.Category = new Category() { CategoryID = (int)aircraftModel.CategoryID, CategoryName = aircraftModel.Category.CategoryName, AdditionalData = aircraftModel.AdditionalData };
                aircraftMod.EngineType = new EngineType() { EngineTypeID = (int)aircraftModel.EngineType.EngineTypeID, EngineTypeName = aircraftModel.EngineType.EngineTypeName, ManufacturerID = (int)aircraftModel.ManufacturerID, AdditionalData = aircraftModel.AdditionalData };
                aircraftMod.Description = aircraftModel.Description;
                aircraftMod.ModelName = aircraftModel.ModelName;
                aircraftMod.Manufacturer = new Manufacturer() { ManufacturerID = (int)aircraftModel.ManufacturerID, Name = aircraftModel.ModelName, Description = aircraftModel.Description, AdditionalData = aircraftModel.AdditionalData };
                aircraftMod.ImagePath = aircraftModel.ImagePath;
                aircraftMod.AdditionalData = aircraftModel.AdditionalData;

                result.Add(aircraftMod);
            }

            return result;
        }

        public int Save(object aircraftModel)
        {
            //TODO
            //this.mAircraftModel = aircraftModel as AircraftModel;
            return -1;
        }

        public int Insert(object aircraftModel)
        {
            this.mAircraftModel = aircraftModel as AircraftModel;

            //DataAccess.AircraftModel aircraftMod = new DataAccess.AircraftModel();
            //aircraftMod.Category = new DataAccess.Category() { CategoryID = mAircraftModel.Category.CategoryID, CategoryName = mAircraftModel.Category.CategoryName, AdditionalData = mAircraftModel.Category.AdditionalData };
            //aircraftMod.EngineType = new DataAccess.EngineType() { EngineTypeID = mAircraftModel.EngineType.EngineTypeID, EngineTypeName = mAircraftModel.EngineType.EngineTypeName, AdditionalData = mAircraftModel.EngineType.AdditionalData };
            //aircraftMod.Manufacturer = new DataAccess.Manufacturer() { ManufacturerID = mAircraftModel.Manufacturer.ManufacturerID, ManufacturerName = mAircraftModel.Manufacturer.Name, AdditionalData = mAircraftModel.Manufacturer.AdditionalData, Description = mAircraftModel.Manufacturer.Description };
            //aircraftMod.ImagePath = mAircraftModel.ImagePath;
            //aircraftMod.Description = mAircraftModel.Description;
            //aircraftMod.AdditionalData = mAircraftModel.AdditionalData;

            DataProvidor dp = new DataProvidor();
            dp.AddAircraftModel(mAircraftModel.Manufacturer.Name, mAircraftModel.Description, mAircraftModel.AdditionalData, mAircraftModel.Category.CategoryID, mAircraftModel.EngineType.EngineTypeID, mAircraftModel.Manufacturer.ManufacturerID, mAircraftModel.ImagePath);
            return -1;
        }

        public void DeleteOne(object aircraftModel)
        {
            this.mAircraftModel = aircraftModel as AircraftModel;
            DataProvidor dp = new DataProvidor();

            dp.DeleteAircraftModel(mAircraftModel.AircraftModelID);

        }
    }
}
