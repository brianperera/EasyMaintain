using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
    public class SparePart : IBusiness
    {

        SparePart mSparePart;

        public int SparePartID { get; set; }
        public Category Category { get; set; }
        public string SparePartName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string AdditionalData { get; set; }

        public SparePart()
        {

        }

        public object GetData()
        {
            List<SparePart> result = new List<SparePart>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.SparePart sparePart in dp.GetSparePartsData())
            {
                SparePart _sparePart = new SparePart();

                _sparePart.SparePartID = sparePart.SparePartID;
                _sparePart.Category = new Category() { CategoryID = (int)sparePart.Category.CategoryID, AdditionalData = sparePart.Category.AdditionalData };
                _sparePart.SparePartName = sparePart.SparePartName;
                _sparePart.Description = sparePart.Description;
                _sparePart.ImagePath = sparePart.ImagePath;
                _sparePart.AdditionalData = sparePart.AdditionalData;

                result.Add(_sparePart);
            }

            return result;
        }

        public int Save(object sparePart)
        {
            //TODO
            this.mSparePart = sparePart as SparePart;
            return -1;
        }

        public int Insert(object sparePart)
        {
            this.mSparePart = sparePart as SparePart;
            DataProvidor dp = new DataProvidor();
            dp.AddSparePart(mSparePart.SparePartName, mSparePart.Description, mSparePart.AdditionalData, mSparePart.Category.CategoryID, mSparePart.ImagePath);
            return -1;
        }

        public void DeleteOne(object sparePart)
        {
            this.mSparePart = sparePart as SparePart;
            DataProvidor dp = new DataProvidor();
            dp.DeleteSparePart(mSparePart.SparePartID);
        }

    }
}
