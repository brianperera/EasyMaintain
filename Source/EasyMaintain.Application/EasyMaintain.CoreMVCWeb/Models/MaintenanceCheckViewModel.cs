using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using Newtonsoft.Json;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class MaintenanceCheckViewModel
    {

        public int MaintenanceCheckID { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }
        public int currentIndex { get; set; }

        public List<MaintenanceChecks> Checks { get; set; }

        public MaintenanceCheckViewModel()
        {
            Checks = new List<MaintenanceChecks>();
            
            updateList();

        }
        public void updateList()
        {

            try
            {
                var uri = "api/MaintenanceCheck/Get ";

                List<MaintenanceChecks> maintenanceList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    maintenanceList = JsonConvert.DeserializeObject<List<MaintenanceChecks>>(response.Result);
                }
                Checks = maintenanceList;

            }
            catch (AggregateException e)
            {

            }

        }
    }
}
