using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;

namespace EasyMaintain.CoreWebMVC.Models
{

    //[Table("AircraftModelDetails")]
    //public class AircraftModel
    //{
    //    [Key]
    //    public int AircraftModelID { get; set; }
    //    public string Category { get; set; }
    //    public string ModelName { get; set; }
    //    public string Manufacturer { get; set; }
    //    public string EngineType { get; set; }
    //    public string Description { get; set; }
    //    public string ImagePath { get; set; }
    //    public string AdditionalData { get; set; }   

    //}


    public class AircraftModelModel: UserDataModel
    {
        [Required]
        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        
        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Engine Type")]
        public string EngineType { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Additional Data")]
        public string AdditionalData { get; set; }
        public List<AircraftModel> AircrafModels { get; set; }

        public int AircraftModelID { get; set; }
        public Token token { get; set; }

        public AircraftModelModel()
        {
            AircrafModels = new List<AircraftModel>();

            updateList();
        }

        public void updateList()
        {

            try
            {
                var uri = "api/Aircraftmodel/Get ";

                List<AircraftModel> aircraftList;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task <String> response = httpClient.GetStringAsync(uri);
                    aircraftList = JsonConvert.DeserializeObject<List<AircraftModel>>(response.Result);
                }
                AircrafModels = aircraftList;

            }
            catch (AggregateException e)
            {

            }
        }
        }
}
