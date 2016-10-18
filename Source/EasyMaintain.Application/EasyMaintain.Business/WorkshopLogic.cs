using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DTO;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
   public class WorkshopLogic
    {

        public WorkshopLogic()
        {

        }

        Workshop mWorkshop = new Workshop();



        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>

        public object GetData()
        {
            List<Workshop> result = new List<Workshop>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Workshop workshop in dp.GetWorkshopData())
            {
                Workshop _workshop = new Workshop();
                _workshop.WorkshopID = workshop.WorkshopID;
                _workshop.Name = workshop.Name;
                _workshop.Location = workshop.Location;
                _workshop.Address = workshop.Address;
                

                result.Add(_workshop);
            }

            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="workshop"></param>
        /// <returns></returns>

        public int Save(object workshop)
        {
            //    this.mEngineType = engineType as EngineType;

            //    DataProvidor dp = new DataProvidor();
            //    dp.AddEngineType(mEngineType.WorkID,mEngineType.FlightModel,mEngineType.FlightNumber,mEngineType.Description,mEngineType.StartDate,mEngineType.CompletionDate,mEngineType.Location);

            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="workshop"></param>
        /// <returns></returns>

        public int Insert(object workshop)
        {
            this.mWorkshop = workshop as Workshop;
            DataProvidor dp = new DataProvidor();
            return dp.AddWorkshop(mWorkshop.WorkshopID,mWorkshop.Name,mWorkshop.Location,mWorkshop.Address);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="workshop"></param>

        public void DeleteOne(object workshop)
        {
            this.mWorkshop = workshop as Workshop;

            DataProvidor dp = new DataProvidor();
            dp.DeleteWorkshop(mWorkshop.WorkshopID);

        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="workshop"></param>
        /// <returns></returns>


        public bool UpdateOne(object workshop)
        {
            this.mWorkshop = workshop as Workshop;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateWorkshop(mWorkshop.WorkshopID,mWorkshop.Name,mWorkshop.Location,mWorkshop.Address);
        }

        public Workshop Find(int id)
        {
            List<Workshop> result = new List<Workshop>();
            return result
                .Where(e => e.WorkshopID.Equals(id))
                .SingleOrDefault();
        }

    }

}
