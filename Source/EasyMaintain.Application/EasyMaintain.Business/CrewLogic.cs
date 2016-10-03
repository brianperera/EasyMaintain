using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
  public  class CrewLogic
    {
        Crew mCrew;

        public CrewLogic()
        {

        }


        public void DeleteOne(object crew)
        {

            this.mCrew = crew as Crew;
            DataProvidor dp = new DataProvidor();
            dp.DeleteCrew(mCrew.Name);


        }

        public object GetData()
        {
            List<Crew> result = new List<Crew>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Crew crew in dp.GetCrewData())
            {
                Crew _crew = new Crew();
                _crew.Name = crew.Name;
                _crew.Designation = crew.Designation;


                result.Add(_crew);
            }

            return result;
        }

        public int Insert(object crew)
        {
            this.mCrew = crew as Crew;
            DataProvidor dp = new DataProvidor();
            return dp.AddCrew(mCrew.Name, mCrew.Designation);
        }

        public int Save(object record)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOne(object crew)
        {
            this.mCrew = crew as Crew;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateCrew(mCrew.Name, mCrew.Designation);
        }


        public Crew Find(object Name)
        {
            List<Crew> result = new List<Crew>();
            return result
                .Where(e => e.Name.Equals(Name))
                .SingleOrDefault();
        }





    }
}
