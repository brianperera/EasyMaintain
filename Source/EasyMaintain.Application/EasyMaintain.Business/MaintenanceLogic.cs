using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public class MaintenanceLogic
    {

        public MaintenanceLogic()
        {

        }

        Maintenance mMaintenance = new Maintenance();

        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            List<Maintenance> result = new List<Maintenance>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Maintenance maintenance in dp.GetMaintenanceData())
            {
                Maintenance _maintenance = new Maintenance();
                _maintenance.WorkID = maintenance.WorkID;
                _maintenance.FlightModel = maintenance.FlightModel;
                _maintenance.FlightNumber = maintenance.FlightNumber;
                _maintenance.Description = maintenance.Description;

                result.Add(_maintenance);
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
            return dp.UpdateMaintenance(mMaintenance.WorkID, mMaintenance.FlightModel,mMaintenance.FlightNumber, mMaintenance.Description, mMaintenance.StartDate,mMaintenance.CompletionDate,mMaintenance.Location);
        }

        public Maintenance Find(int id)
        {
            List<Maintenance> result = new List<Maintenance>();
            return result
                .Where(e => e.WorkID.Equals(id))
                .SingleOrDefault();
        }


    }
}
