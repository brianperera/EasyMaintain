using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //TODO
        }

        public object GetData()
        {
            //TODO
            return new List<Supplier>();
        }

        public int Save(object supplier)
        {
            //TODO
            this.mSupplier = supplier as Supplier;
            return -1;
        }

        public int Insert(object supplier)
        {
            //TODO
            this.mSupplier = supplier as Supplier;
            return -1;
        }

        public void DeleteOne(object supplier)
        {
            //TODO
            this.mSupplier = supplier as Supplier;
        }

    }
}
