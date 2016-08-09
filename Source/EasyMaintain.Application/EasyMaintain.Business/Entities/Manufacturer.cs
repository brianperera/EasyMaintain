using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public class Manufacturer : IBusiness
    {

        Manufacturer mManufacturer;

        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }


        public Manufacturer()
        {
            //TODO
        }

        public object GetData()
        {
            //TODO
            return new List<Manufacturer>();
        }

        public int Save(object manufacturer)
        {
            //TODO
            this.mManufacturer = manufacturer as Manufacturer;
            return -1;
        }

        public int Insert(object manufacturer)
        {
            //TODO
            this.mManufacturer = manufacturer as Manufacturer;
            return -1;
        }

        public void DeleteOne(object manufacturer)
        {
            //TODO
            this.mManufacturer = manufacturer as Manufacturer;
        }

    }
}
