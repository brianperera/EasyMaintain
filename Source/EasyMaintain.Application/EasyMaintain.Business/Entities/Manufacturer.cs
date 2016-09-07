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

        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public int Save(object manufacturer)
        {
            //TODO
            this.mManufacturer = manufacturer as Manufacturer;
            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public int Insert(object manufacturer)
        {
            this.mManufacturer = manufacturer as Manufacturer;
            DataProvidor dp = new DataProvidor();
            return dp.AddManufacturer(mManufacturer.Name, mManufacturer.Description, mManufacturer.AdditionalData);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="manufacturer"></param>
        public void DeleteOne(object manufacturer)
        {
            this.mManufacturer = manufacturer as Manufacturer;
            DataProvidor dp = new DataProvidor();
            dp.DeleteManufacturer(mManufacturer.ManufacturerID);
        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public bool UpdateOne(object manufacturer)
        {
            this.mManufacturer = manufacturer as Manufacturer;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateManufacturer(mManufacturer.ManufacturerID, mManufacturer.Name, mManufacturer.Description, mManufacturer.AdditionalData);
        }

        public Manufacturer Find(object key)
        {
            List<Manufacturer> result = new List<Manufacturer>();
            return result
                .Where(e => e.ManufacturerID.Equals(ManufacturerID))
                .SingleOrDefault();
        }

    }
}
