using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.Business;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business.Entities
{
    class Maintenance : IBusiness
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

        public Maintenance()
        {

        }

        public object GetData()
        {
            throw new NotImplementedException();
        }

        public int Save(object record)
        {
            throw new NotImplementedException();
        }

        public int Insert(object record)
        {
            throw new NotImplementedException();
        }

        public void DeleteOne(object record)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOne(object record)
        {
            throw new NotImplementedException();
        }
    }  
}
