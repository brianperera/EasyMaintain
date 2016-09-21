using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;
using EasyMaintain.Business.Entities;

namespace EasyMaintain.Business
{
    public class EngineType : IBusiness
    {

        EngineType mEngineType;
     
        public int WorkID { get; set; }
        public string FlightModel { get; set; }
        public string FlightNumber { get; set; }
        public string  Description { get; set; }
        public string StartDate { get; set; }
        public string CompletionDate { get; set; }
        public string Location { get; set; }
        public List<MaintenanceChecks> CheckItems { get; set; }
        public List<Crew> CrewMembers { get; set; }

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

            foreach (DataAccess.Models.EngineType engineType in dp.GetEngineTypeData())
            {
                EngineType _engineType = new EngineType();
                _engineType.WorkID = engineType.WorkID;
                _engineType.FlightModel = engineType.FlightModel;
                _engineType.FlightNumber = engineType.FlightNumber;
                _engineType. Description = engineType. Description;

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
        //    this.mEngineType = engineType as EngineType;

        //    DataProvidor dp = new DataProvidor();
        //    dp.AddEngineType(mEngineType.WorkID,mEngineType.FlightModel,mEngineType.FlightNumber,mEngineType.Description,mEngineType.StartDate,mEngineType.CompletionDate,mEngineType.Location);

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
            return dp.AddEngineType(mEngineType.WorkID, mEngineType.FlightModel, mEngineType.FlightNumber, mEngineType.Description, mEngineType.StartDate, mEngineType.CompletionDate, mEngineType.Location);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="engineType"></param>
        public void DeleteOne(object engineType)
        {
            this.mEngineType = engineType as EngineType;

            DataProvidor dp = new DataProvidor();
            dp.DeleteEngineType(mEngineType.WorkID.ToString());

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
            return dp.UpdateEngineType(mEngineType.WorkID.ToString(), mEngineType.FlightModel, mEngineType. Description);
        }

        public EngineType Find(object WorkID)
        {
            List<EngineType> result = new List<EngineType>();
            return result
                .Where(e => e.WorkID.Equals(WorkID))
                .SingleOrDefault();
        }
    }
}
