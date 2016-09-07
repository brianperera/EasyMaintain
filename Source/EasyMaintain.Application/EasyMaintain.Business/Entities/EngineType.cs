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

        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public int Save(object engineType)
        {
            //this.mEngineType = engineType as EngineType;

            //DataProvidor dp = new DataProvidor();
            //dp.AddEngineType(mEngineType.EngineTypeName, mEngineType.AdditionalData);

            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public int Insert(object engineType)
        {
            this.mEngineType = engineType as EngineType;
            DataProvidor dp = new DataProvidor();
            return dp.AddEngineType(mEngineType.EngineTypeName, mEngineType.AdditionalData);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="engineType"></param>
        public void DeleteOne(object engineType)
        {
            this.mEngineType = engineType as EngineType;

            DataProvidor dp = new DataProvidor();
            dp.DeleteEngineType(mEngineType.EngineTypeID);

        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public bool UpdateOne(object engineType)
        {
            this.mEngineType = engineType as EngineType;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateEngineType(mEngineType.EngineTypeID, mEngineType.EngineTypeName, mEngineType.AdditionalData);
        }

        public EngineType Find(object key)
        {
            List<EngineType> result = new List<EngineType>();
            return result
                .Where(e => e.EngineTypeID.Equals(EngineTypeID))
                .SingleOrDefault();
        }
    }
}
