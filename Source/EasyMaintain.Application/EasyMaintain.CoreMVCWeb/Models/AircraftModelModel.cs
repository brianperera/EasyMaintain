using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMaintain.DTO;


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


    public class AircraftModelModel
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

        public AircraftModelModel()
        {
            AircrafModels = new List<AircraftModel>
            {
                new AircraftModel
                {
                    AircraftModelID = 1,
                    Manufacturer = "Airbus",
                    ModelName = "A300"
                },
                new AircraftModel
                {
                    AircraftModelID = 2,
                    Manufacturer = "Boeing",
                    ModelName = "717"
                },
                new AircraftModel
                {
                    AircraftModelID = 3,
                    Manufacturer = "Bombardier",
                    ModelName = "CRJ-100"
                },
                new AircraftModel
                {
                    AircraftModelID = 4,
                    Manufacturer = "Antonov",
                    ModelName = "An-140"
                },
                new AircraftModel
                {
                    AircraftModelID = 5,
                    Manufacturer = "Airspeed",
                    ModelName = "Ambassador"
                }
            };
        }
    }
}
