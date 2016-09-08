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

        // Constructor
        public Category()
        {

        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            List<Category> result = new List<Category>();
            DataProvidor dp = new DataProvidor();

            foreach (DataAccess.Models.Category category in dp.GetCategoryData())
            {
                Category _category = new Category();
                _category.CategoryID = category.CategoryID;
                _category.CategoryName = category.CategoryName;
                _category.AdditionalData = category.AdditionalData;

                result.Add(_category);
            }

            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int Save(object category)
        {
            ////TODO
            //this.mCategory = category as Category;
            return -1;
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int Insert(object category)
        {
            this.mCategory = category as Category;
            DataProvidor dp = new DataProvidor();
            return dp.AddCategory(mCategory.CategoryName, mCategory.AdditionalData);
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="category"></param>
        public void DeleteOne(object category)
        {
            this.mCategory = category as Category;

            DataProvidor dp = new DataProvidor();
            dp.DeleteCategory(mCategory.CategoryID);
        }

        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool UpdateOne(object category)
        {
            this.mCategory = category as Category;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateCategory(mCategory.CategoryID, mCategory.CategoryName, mCategory.AdditionalData);
        }

        public Category Find(object key)
        {
            List<Category> result = new List<Category>();
            return result
                .Where(e => e.CategoryID.Equals(CategoryID))
                .SingleOrDefault();
        }
    }
}
