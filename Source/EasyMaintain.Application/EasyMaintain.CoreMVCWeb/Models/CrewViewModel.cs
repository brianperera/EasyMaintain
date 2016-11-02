using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using Newtonsoft.Json;
using EasyMaintain.CoreWebMVC.Utility;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;

namespace EasyMaintain.CoreWebMVC.Models
{
    //public class Crew
    //{
    //    [Key]
    //    public int CrewID { get; set; }
    //    public string Name { get; set; }
    //    public string Designation { get; set; }
    //}

    public class CrewViewModel: UserDataModel
    {
       // CrewViewModel crewViewModel;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public int currentIndex { get; set; }
        public List<Crew> CrewList { get; set; }
        public Token token { get; set; }
        public CrewViewModel()
        {
            CrewList = new List<Crew>();   
            updateList();


        }

        public void updateList()
        {

            try
            {
                var uri = "api/Crew/Get ";

                List<Crew> crewList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    crewList = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
                }
               CrewList = crewList;

            }
            catch (AggregateException e)
            {

            }

        }




    }
}
