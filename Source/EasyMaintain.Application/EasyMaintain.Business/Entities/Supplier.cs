using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
    public class Supplier : IBusiness
    {

        Supplier mSupplier;

        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalData { get; set; }

        public Supplier()
        {

        }

        public object GetData()
        {
            List<Supplier> result = new List<Supplier>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Supplier supplier in dp.GetSupplierData())
            {
                Supplier _supplier = new Supplier();
                _supplier.SupplierID = supplier.SupplierID;
                _supplier.Name = supplier.SupplierName;
                _supplier.Description = supplier.Description;
                _supplier.Address = supplier.Address;
                _supplier.ContactDetails = supplier.ContactDetails;
                _supplier.EmailAddress = supplier.EmailAddress;
                _supplier.AdditionalData = supplier.AdditionalData;

                result.Add(_supplier);
            }
            return result;
        }

        public int Save(object supplier)
        {
            //TODO
            this.mSupplier = supplier as Supplier;
            return -1;
        }

        public int Insert(object supplier)
        {
            this.mSupplier = supplier as Supplier;
            DataProvidor dp = new DataProvidor();
            dp.AddSupplier(mSupplier.Name, mSupplier.EmailAddress, mSupplier.Address, mSupplier.ContactDetails, mSupplier.Description, mSupplier.AdditionalData);
            return -1;
        }

        public void DeleteOne(object supplier)
        {
            this.mSupplier = supplier as Supplier;
            DataProvidor dp = new DataProvidor();
            dp.DeleteSupplier(mSupplier.SupplierID);
        }

    }
}
