using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

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

        }

        public object GetData()
        {
            List<Manufacturer> result = new List<Manufacturer>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Manufacturer manufacturer in dp.GetManufacturerData())
            {
                Manufacturer _manufacturer = new Manufacturer();
                _manufacturer.ManufacturerID = manufacturer.ManufacturerID;
                _manufacturer.Name = manufacturer.ManufacturerName;
                _manufacturer.Description = manufacturer.Description;
                _manufacturer.AdditionalData = manufacturer.AdditionalData;

                result.Add(_manufacturer);
            }

            return result;
        }

        public int Save(object manufacturer)
        {
            //TODO
            this.mManufacturer = manufacturer as Manufacturer;
            return -1;
        }

        public int Insert(object manufacturer)
        {
            this.mManufacturer = manufacturer as Manufacturer;
            DataProvidor dp = new DataProvidor();
            dp.AddManufacturer(mManufacturer.Name, mManufacturer.Description, mManufacturer.AdditionalData);
            return -1;
        }

        public void DeleteOne(object manufacturer)
        {
            this.mManufacturer = manufacturer as Manufacturer;
            DataProvidor dp = new DataProvidor();
            dp.DeleteManufacturer(mManufacturer.ManufacturerID);
        }

    }
}
