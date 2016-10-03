using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DTO;

namespace EasyMaintain.Business
{
   public class SupplierLogic
    {

        Supplier mSupplier;

        public SupplierLogic()
        {

        }
        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        /// 
        List<Supplier> result = new List<Supplier>();
        public object GetData()
        {
            //List<Supplier> result = new List<Supplier>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Supplier supplier in dp.GetSupplierData())
            {
                Supplier _supplier = new Supplier();
                _supplier.SupplierID = supplier.SupplierID;
                _supplier.Name = supplier.Name;
                _supplier.Description = supplier.Description;
                _supplier.Address = supplier.Address;
                _supplier.ContactDetails = supplier.ContactDetails;
                _supplier.EmailAddress = supplier.EmailAddress;
                _supplier.AdditionalData = supplier.AdditionalData;

                result.Add(_supplier);
            }
            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public int Save(object supplier)
        {
            //TODO
            this.mSupplier = supplier as Supplier;
            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public int Insert(object supplier)
        {
            this.mSupplier = supplier as Supplier;
            DataProvidor dp = new DataProvidor();
            return dp.AddSupplier(mSupplier.Name, mSupplier.EmailAddress, mSupplier.Address, mSupplier.ContactDetails, mSupplier.Description, mSupplier.AdditionalData);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="supplier"></param>
        public void DeleteOne(object supplier)
        {
            this.mSupplier = supplier as Supplier;
            DataProvidor dp = new DataProvidor();
            dp.DeleteSupplier(mSupplier.SupplierID);
        }

        //finding the supplier ID
        public Supplier Find(object SupplierID)
        {
            return result
                .Where(e => e.SupplierID.Equals(SupplierID))
                .SingleOrDefault();
        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public bool UpdateOne(object supplier)
        {
            this.mSupplier = supplier as Supplier;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateSupplier(mSupplier.SupplierID, mSupplier.Name, mSupplier.EmailAddress, mSupplier.Address, mSupplier.ContactDetails, mSupplier.Description, mSupplier.AdditionalData);
        }

       

    }
}
