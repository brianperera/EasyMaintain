using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;

namespace EasyMaintain.Business
{
    public class Category : IBusiness
    {

        Category mCategory;

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string AdditionalData { get; set; }


        public Category()
        {

        }

        public object GetData()
        {
            List<Category> result = new List<Category>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Category category in dp.GetCategoryData())
            {
                Category _category = new Category();
                _category.CategoryID = category.CategoryID;
                _category.CategoryName = category.CategoryName;
                _category.AdditionalData = category.AdditionalData;

                result.Add(_category);
            }

            return result;
        }

        public int Save(object category)
        {
            ////TODO
            //this.mCategory = category as Category;
            return -1;
        }

        public int Insert(object category)
        {
            this.mCategory = category as Category;

            DataProvidor dp = new DataProvidor();
            dp.AddCategory(mCategory.CategoryName, mCategory.AdditionalData);

            return -1;
        }

        public void DeleteOne(object category)
        {
            this.mCategory = category as Category;

            DataProvidor dp = new DataProvidor();
            dp.DeleteCategory(mCategory.CategoryID);
        }

    }
}
