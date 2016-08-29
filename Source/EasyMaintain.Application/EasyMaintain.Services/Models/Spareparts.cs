using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyMaintain.Business;




namespace EasyMaintain.Services.Models
{
    public class Spareparts
    {
        public string Description { get; set; }
        public int AircrafModelId { get; set; }
        public int ManufacturerId { get; set; }
        public int SupplierId { get; set; }

        public IEnumerable<AircraftModel> AircrafModels { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public List<SparePart> SpareParts { get; set; }




    }
}