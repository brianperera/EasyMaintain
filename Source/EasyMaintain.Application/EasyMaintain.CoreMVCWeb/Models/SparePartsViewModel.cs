using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Models.AccountViewModels;

namespace EasyMaintain.CoreWebMVC.Models
{
    [Table("SparePart")]
    public class SparePart
    {
        [Key]
        public int SparePartID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SparePartsViewModel: UserDataModel
    {
        [Required]
        [Display(Name = "Spare Part Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Spare Part Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Spare Part ID")]
        public int SparePartID { get; set; }

        public int AircrafModelId { get; set; }
        public int ManufacturerId { get; set; }
        public int SupplierId { get; set; }

        public IEnumerable<AircraftModel> AircrafModels { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public List<SparePart> SpareParts { get; set; }

        public SparePartsViewModel()
        {
            SpareParts = new List<SparePart>
            {
                new SparePart
                {
                    SparePartID = 1,
                    Name = "Wing",
                    Description = "This is the aircraft Wing"
                },
                new SparePart
                {
                    SparePartID = 2,
                    Name = "Glass",
                    Description = "This is the aircraft Glass"
                },
                new SparePart
                {
                    SparePartID = 3,
                    Name = "Engine",
                    Description = "This is the aircraft Engine"
                }
            };

            AircrafModels = new List<AircraftModel> 
            { 
                new AircraftModel 
                {
                    AircraftModelID = 1,
                    ModelName = "Airbus A300"
                },
                new AircraftModel 
                {
                    AircraftModelID = 2,
                    ModelName = "Boeing 717"
                },
                new AircraftModel 
                {
                    AircraftModelID = 3,
                    ModelName = "Bombardier CRJ-100"
                },
                new AircraftModel 
                {
                    AircraftModelID = 4,
                    ModelName = "Antonov An-140"
                },
                new AircraftModel 
                {
                    AircraftModelID = 5,
                    ModelName = "Airspeed Ambassador"
                }
            };

            Manufacturers = new List<Manufacturer> { 
                new Manufacturer
                {
                    ManufacturerID = 1,
                    Name = "Boeing"
                },
                new Manufacturer
                {
                    ManufacturerID = 1,
                    Name = "Airbus"
                }
            };

            Suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierID = 1,
                    Name = "Supplier A"
                },
                new Supplier
                {
                    SupplierID = 2,
                    Name = "Supplier B"
                }
            };
        }
    }
}
