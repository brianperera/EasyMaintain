using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using Newtonsoft.Json;

namespace EasyMaintain.CoreWebMVC.Models
{
    //public class Workshop
    //{
    //    public int WorkshopID { get; set; }
    //    public string Name { get; set; }
    //    public string Location { get; set; }
    //    public string Address { get; set; }
    //}
    public class WorkshopModel
    {
        [Required]
        [Display(Name = "Workshop Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public List<Workshop> Workshops { get; set; }

        public int WorkshopID { get; set; }

        public WorkshopModel()

        {
            Workshops = new List<Workshop>();

            updateList();


        }



        public void updateList()
        {

            try
            {
                var uri = "api/Workshop/Get ";

                List<Workshop> workshopList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    workshopList = JsonConvert.DeserializeObject<List<Workshop>>(response.Result);
                }
                Workshops = workshopList;

            }
            catch (AggregateException e)
            {

            }

        }
    }
}
