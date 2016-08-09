using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
    public class SparePart : IBusiness
    {

        SparePart mSparePart;

        public int SparePartID { get; set; }
        public string Category { get; set; }
        public string SparePartName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }

        public SparePart()
        {
            //TODO
        }

        public object GetData()
        {
            //TODO
            return new List<SparePart>();
        }

        public int Save(object sparePart)
        {
            //TODO
            this.mSparePart = sparePart as SparePart;
            return -1;
        }

        public int Insert(object sparePart)
        {
            //TODO
            this.mSparePart = sparePart as SparePart;
            return -1;
        }

        public void DeleteOne(object sparePart)
        {
            //TODO
            this.mSparePart = sparePart as SparePart;
        }

    }
}
