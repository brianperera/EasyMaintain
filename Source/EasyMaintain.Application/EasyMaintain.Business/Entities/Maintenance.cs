using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;
using EasyMaintain.Business.Entities;



namespace EasyMaintain.Business
{
    public class Maintenance : IBusiness
    {

        Maintenance mMaintenance;

        public int WorkID { get; set; }
        public string FlightModel { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string CompletionDate { get; set; }
        public string Location { get; set; }
        public List<MaintenanceChecks> CheckItems { get; set; }
        public List<Crew> CrewMembers { get; set; }



        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            List<Maintenance> result = new List<Maintenance>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Models.Maintenance engineType in dp.GetMaintenanceData())
            {
                Maintenance _engineType = new Maintenance();
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
            this.mMaintenance = engineType as Maintenance;
            DataProvidor dp = new DataProvidor();
            return dp.AddMaintenance(mMaintenance.WorkID, mMaintenance.FlightModel, mMaintenance.FlightNumber, mMaintenance.Description, mMaintenance.StartDate, mMaintenance.CompletionDate, mMaintenance.Location);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="engineType"></param>
        public void DeleteOne(object engineType)
        {
            this.mMaintenance = engineType as Maintenance;

            DataProvidor dp = new DataProvidor();
            dp.DeleteMaintenance(mMaintenance.WorkID.ToString());

        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="engineType"></param>
        /// <returns></returns>
        public bool UpdateOne(object engineType)
        {
            this.mMaintenance = engineType as Maintenance;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateMaintenance(mMaintenance.WorkID.ToString(), mMaintenance.FlightModel, mMaintenance. Description);
        }

        public Maintenance Find(object WorkID)
        {
            List<Maintenance> result = new List<Maintenance>();
            return result
                .Where(e => e.WorkID.Equals(WorkID))
                .SingleOrDefault();
        }
    }
}
