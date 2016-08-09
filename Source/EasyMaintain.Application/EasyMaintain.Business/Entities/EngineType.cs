using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
    public class EngineType : IBusiness
    {

        EngineType mEngineType;

        public int EngineTypeID { get; set; }
        public string EngineTypeName { get; set; }
        public int ManufacturerID { get; set; }
        public string AdditionalData { get; set; }

        public EngineType()
        {

        }

        public object GetData()
        {
            List<EngineType> result = new List<EngineType>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.EngineType engineType in dp.GetEngineTypeData())
            {
                EngineType _engineType = new EngineType();
                _engineType.EngineTypeID = engineType.EngineTypeID;
                _engineType.EngineTypeName = engineType.EngineTypeName;
                _engineType.AdditionalData = engineType.AdditionalData;

                result.Add(_engineType);
            }

            return result;
        }

        public int Save(object engineType)
        {
            //this.mEngineType = engineType as EngineType;

            //DataProvidor dp = new DataProvidor();
            //dp.AddEngineType(mEngineType.EngineTypeName, mEngineType.AdditionalData);

            return -1;
        }

        public int Insert(object engineType)
        {
            this.mEngineType = engineType as EngineType;
            DataProvidor dp = new DataProvidor();
            dp.AddEngineType(mEngineType.EngineTypeName, mEngineType.AdditionalData);
            return -1;
        }

        public void DeleteOne(object engineType)
        {
            this.mEngineType = engineType as EngineType;

            DataProvidor dp = new DataProvidor();
            dp.DeleteEngineType(mEngineType.EngineTypeID);

        }

    }
}
