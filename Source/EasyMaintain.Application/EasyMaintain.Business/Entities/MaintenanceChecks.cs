using EasyMaintain.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public class MaintenanceChecks : IBusiness
    {
        MaintenanceChecks mMaintenanceChecks;
        public string MaintenanceCheckID { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }

        public MaintenanceChecks()
        {


        }

        public void DeleteOne(object maintenanceCheck)
        {
            this.mMaintenanceChecks = maintenanceCheck as MaintenanceChecks;
            DataProvidor dp = new DataProvidor();
            dp.DeleteCrew(mMaintenanceChecks.Description);
        }

        public object GetData()
        {
            List<MaintenanceChecks> result = new List<MaintenanceChecks>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Models.MaintenanceChecks maintenanceCheck in dp.GetMaintenanceCheckData())
            {
                MaintenanceChecks _maintenanceCheck = new MaintenanceChecks();
                _maintenanceCheck.Description = maintenanceCheck.Description;
                _maintenanceCheck.status = maintenanceCheck.status;

                result.Add(_maintenanceCheck);
            }

            return result;
        }

        public int Insert(object maintenanceCheck)
        {
            this.mMaintenanceChecks = maintenanceCheck as MaintenanceChecks;
            DataProvidor dp = new DataProvidor();
            return dp.AddMaintenanceChecks(mMaintenanceChecks.Description, (mMaintenanceChecks.status));
        }

        public int Save(object record)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOne(object maintenanceCheck)
        {
            this.mMaintenanceChecks = maintenanceCheck as MaintenanceChecks;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateMaintenanceChecks(mMaintenanceChecks.Description, mMaintenanceChecks.status);
        }

        public MaintenanceChecks Find(object key)
        {
            List<MaintenanceChecks> result = new List<MaintenanceChecks>();
            return result
                .Where(e => e.MaintenanceCheckID.Equals(MaintenanceCheckID))
                .SingleOrDefault();
        }
    }
}
