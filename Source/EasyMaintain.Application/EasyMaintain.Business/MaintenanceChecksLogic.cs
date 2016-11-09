using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
   public class MaintenanceChecksLogic
    {
        MaintenanceChecks mMaintenanceChecks;

        public MaintenanceChecksLogic()
        {
        }
            public void DeleteOne(object maintenanceCheck)
        {
            this.mMaintenanceChecks = maintenanceCheck as MaintenanceChecks;
            DataProvidor dp = new DataProvidor();
            dp.DeleteMaintenanceChecks(mMaintenanceChecks.MaintenanceCheckID);
        }
        public object GetData()
        {
            List<MaintenanceChecks> result = new List<MaintenanceChecks>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.MaintenanceChecks maintenanceCheck in dp.GetMaintenanceCheckData())
            {
                MaintenanceChecks _maintenanceCheck = new MaintenanceChecks();
                _maintenanceCheck.MaintenanceCheckID = maintenanceCheck.MaintenanceCheckID;
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
            return dp.UpdateMaintenanceChecks(mMaintenanceChecks.MaintenanceCheckID, mMaintenanceChecks.Description, mMaintenanceChecks.status);
        }

        public MaintenanceChecks Find(object maintenanceCheckID)
        {
            List<MaintenanceChecks> result = new List<MaintenanceChecks>();
            return result
                .Where(e => e.MaintenanceCheckID.Equals(maintenanceCheckID))
                .SingleOrDefault();
        }


    }
    }

