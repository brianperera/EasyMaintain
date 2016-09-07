using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EasyMaintain.DataAccess
{
    public class DataProvidor
    {
    



/// <summary>
/// Get Supplier Data
/// </summary>
/// <returns></returns>
///           
public List<Supplier> GetSupplierData()
        {
            List<Supplier> supplierList = new List<Supplier>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.Suppliers
                            orderby b.SupplierName
                            select b;

                foreach (var item in query)
                {
                    supplierList.Add(item as Supplier);
                }
            }

            return supplierList;
        }

        /// <summary>
        /// Get Spare Parts Data
        /// </summary>
        /// <returns></returns>
        public List<SparePart> GetSparePartsData()
        {
            List<SparePart> sparePartsList = new List<SparePart>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.SpareParts
                            orderby b.SparePartName
                            select b;

                foreach (var item in query)
                {
                    sparePartsList.Add(item as SparePart);
                }
            }

            return sparePartsList;
        }

        /// <summary>
        /// Get Manufacturer Data
        /// </summary>
        /// <returns></returns>
        public List<Manufacturer> GetManufacturerData()
        {
            List<Manufacturer> manufacturer = new List<Manufacturer>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.Manufacturers
                            orderby b.ManufacturerName
                            select b;

                foreach (var item in query)
                {
                    manufacturer.Add(item as Manufacturer);
                }
            }

            return manufacturer;
        }

        /// <summary>
        /// Get Aircraft Model Data
        /// </summary>
        /// <returns></returns>
        public List<AircraftModel> GetAircraftModelData()
        {
            List<AircraftModel> aircraftModel = new List<AircraftModel>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.AircraftModels
                            orderby b.ModelName
                            select b;

                foreach (var item in query)
                {
                    aircraftModel.Add(item as AircraftModel);
                }
            }

            return aircraftModel;
        }

        /// <summary>
        /// Get Category Data
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoryData()
        {
            List<Category> category = new List<Category>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.Categories
                            orderby b.CategoryName
                            select b;

                foreach (var item in query)
                {
                    category.Add(item as Category);
                }
            }

            return category;
        }

        /// <summary>
        /// Get Engine Type Data
        /// </summary>
        /// <returns></returns>
        public List<EngineType> GetEngineTypeData()
        {
            List<EngineType> engineType = new List<EngineType>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.EngineTypes
                            orderby b.EngineTypeName
                            select b;

                foreach (var item in query)
                {
                    engineType.Add(item as EngineType);
                }
            }

            return engineType;
        }

        /// <summary>
        /// Get Inventory Data
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetInventoryData()
        {
            List<Inventory> inventory = new List<Inventory>();

            using (var db = new EasyMaintainEntities())
            {
                var query = from b in db.Inventories
                            orderby b.InventoryID
                            select b;

                foreach (var item in query)
                {
                    inventory.Add(item as Inventory);
                }
            }

            return inventory;
        }


        //--- Insert Data

        /// <summary>
        /// Add Supplier
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="address"></param>
        /// <param name="contact"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public int AddSupplier(string supplierName, string emailAddress, string address, string contact, string description, string additionalData)
        {
            int recordId = -1;
            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var supplier = db.Set<Supplier>();
                    supplier.Add(new Supplier { SupplierName = supplierName, EmailAddress = emailAddress, Address = address, ContactDetails = contact, Description = description, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<Supplier>().LastOrDefault().SupplierID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Add Manufacturer
        /// </summary>
        /// <param name="manufacturerName"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public int AddManufacturer(string manufacturerName, string description, string additionalData)
        {
            int recordId = -1;

            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var manufacturer = db.Set<Manufacturer>();
                    manufacturer.Add(new Manufacturer { ManufacturerName = manufacturerName, Description = description, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<Manufacturer>().LastOrDefault().ManufacturerID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public int AddCategory(string categoryName, string additionalData)
        {
            int recordId = -1;

            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var category = db.Set<Category>();
                    category.Add(new Category { CategoryName = categoryName, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<Category>().LastOrDefault().CategoryID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Add Engine Type
        /// </summary>
        /// <param name="engineTypeName"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public int AddEngineType(string engineTypeName, string additionalData)
        {
            int recordId = -1;

            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var engineType = db.Set<EngineType>();
                    engineType.Add(new EngineType { EngineTypeName = engineTypeName, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<EngineType>().LastOrDefault().EngineTypeID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Add Aircraft Model
        /// </summary>
        /// <param name="aircraftModelname"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <param name="categoryID"></param>
        /// <param name="engineTypeId"></param>
        /// <param name="manufacturerId"></param>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        public int AddAircraftModel(string aircraftModelname, string description, string additionalData, int categoryID, int engineTypeId, int manufacturerId, string imagepath)
        {
            int recordId = -1;

            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var aircraftModel = db.Set<AircraftModel>();
                    aircraftModel.Add(new AircraftModel { ModelName = aircraftModelname, CategoryID = categoryID, EngineTypeID = engineTypeId, ManufacturerID = manufacturerId, ImagePath = imagepath, Description = description, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<AircraftModel>().LastOrDefault().AircraftModelID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Add Spare Part
        /// </summary>
        /// <param name="sparePartName"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <param name="categoryID"></param>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        public int AddSparePart(string sparePartName, string description, string additionalData, int categoryID, string imagepath)
        {

            int recordId = -1;

            // insert
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var sparePart = db.Set<SparePart>();
                    sparePart.Add(new SparePart { SparePartName = sparePartName, CategoryID = categoryID, ImagePath = imagepath, Description = description, AdditionalData = additionalData });

                    db.SaveChanges();

                    recordId = db.Set<SparePart>().LastOrDefault().SparePartID;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return recordId;
        }


        //---- Update Data

        /// <summary>
        /// Update Supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="supplierName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="address"></param>
        /// <param name="contact"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public bool UpdateSupplier(int supplierId, string supplierName, string emailAddress, string address, string contact, string description, string additionalData)
        {
            bool result = false;
            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var supplier = db.Suppliers.SingleOrDefault(s => s.SupplierID == supplierId);

                    if (supplier != null)
                    {
                        supplier.SupplierName = supplierName;
                        supplier.EmailAddress = emailAddress;
                        supplier.Address = address;
                        supplier.ContactDetails = contact;
                        supplier.Description = description;
                        supplier.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Update Manufacturer
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <param name="manufacturerName"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public bool UpdateManufacturer(int manufacturerId, string manufacturerName, string description, string additionalData)
        {
            bool result = false;

            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var manufacturer = db.Manufacturers.SingleOrDefault(s => s.ManufacturerID == manufacturerId);

                    if (manufacturer != null)
                    {
                        manufacturer.ManufacturerName = manufacturerName;
                        manufacturer.Description = description;
                        manufacturer.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public bool UpdateCategory(int categoryId, string categoryName, string additionalData)
        {
            bool result = false;

            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var category = db.Categories.SingleOrDefault(s => s.CategoryID == categoryId);

                    if (category != null)
                    {
                        category.CategoryName = categoryName;
                        category.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Update Engine Type
        /// </summary>
        /// <param name="engineTypeId"></param>
        /// <param name="engineTypeName"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        public bool UpdateEngineType(int engineTypeId, string engineTypeName, string additionalData)
        {
            bool result = false;

            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var engineType = db.EngineTypes.SingleOrDefault(s => s.EngineTypeID == engineTypeId);

                    if (engineType != null)
                    {
                        engineType.EngineTypeName = engineTypeName;
                        engineType.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Update Aircraft Model 
        /// </summary>
        /// <param name="aircraftModleId"></param>
        /// <param name="aircraftModelname"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <param name="categoryID"></param>
        /// <param name="engineTypeId"></param>
        /// <param name="manufacturerId"></param>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        public bool UpdateAircraftModel(int aircraftModleId, string aircraftModelname, string description, string additionalData, int categoryID, int engineTypeId, int manufacturerId, string imagepath)
        {
            bool result = false;

            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var aircraftModel = db.AircraftModels.SingleOrDefault(s => s.AircraftModelID == aircraftModleId);

                    if (aircraftModel != null)
                    {
                        aircraftModel.ModelName = aircraftModelname;
                        aircraftModel.CategoryID = categoryID;
                        aircraftModel.EngineTypeID = engineTypeId;
                        aircraftModel.ManufacturerID = manufacturerId;
                        aircraftModel.ImagePath = imagepath;
                        aircraftModel.Description = description;
                        aircraftModel.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }

            return result;
        }

        /// <summary>
        /// Update Spare Part
        /// </summary>
        /// <param name="sparePartId"></param>
        /// <param name="sparePartName"></param>
        /// <param name="description"></param>
        /// <param name="additionalData"></param>
        /// <param name="categoryID"></param>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        public bool UpdateSparePart(int sparePartId, string sparePartName, string description, string additionalData, int categoryID, string imagepath)
        {
            bool result = false;

            // update
            using (var db = new EasyMaintainEntities())
            {
                try
                {
                    var sparePart = db.SpareParts.SingleOrDefault(s => s.SparePartID == sparePartId);

                    if (sparePart != null)
                    {
                        sparePart.SparePartName = sparePartName;
                        sparePart.CategoryID = categoryID;
                        sparePart.ImagePath = imagepath;
                        sparePart.Description = description;
                        sparePart.AdditionalData = additionalData;
                    }
                    db.SaveChanges();
                    result = true;

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return result;
        }


        //--- Delete Data

        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="supplierId"></param>
        public void DeleteSupplier(int supplierId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var supplier = db.Suppliers.SingleOrDefault(s => s.SupplierID == supplierId);
                db.Suppliers.Attach(supplier);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Manufacturer 
        /// </summary>
        /// <param name="manufacturerId"></param>
        public void DeleteManufacturer(int manufacturerId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var manufacturer = db.Manufacturers.SingleOrDefault(s => s.ManufacturerID == manufacturerId);
                db.Manufacturers.Attach(manufacturer);
                db.Manufacturers.Remove(manufacturer);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId"></param>
        public void DeleteCategory(int categoryId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var category = db.Categories.SingleOrDefault(s => s.CategoryID == categoryId);
                db.Categories.Attach(category);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Engine Type
        /// </summary>
        /// <param name="engineTypeId"></param>
        public void DeleteEngineType(int engineTypeId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var engineType = db.EngineTypes.SingleOrDefault(s => s.EngineTypeID == engineTypeId);
                db.EngineTypes.Attach(engineType);
                db.EngineTypes.Remove(engineType);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Aircraft Model 
        /// </summary>
        /// <param name="aircraftModleId"></param>
        public void DeleteAircraftModel(int aircraftModleId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var aircraftModel = db.AircraftModels.SingleOrDefault(s => s.AircraftModelID == aircraftModleId);
                db.AircraftModels.Attach(aircraftModel);
                db.AircraftModels.Remove(aircraftModel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Spare Part
        /// </summary>
        /// <param name="sparePartId"></param>
        public void DeleteSparePart(int sparePartId)
        {
            // Delete
            using (var db = new EasyMaintainEntities())
            {
                var sparePart = db.SpareParts.SingleOrDefault(s => s.SparePartID == sparePartId);
                db.SpareParts.Attach(sparePart);
                db.SpareParts.Remove(sparePart);
                db.SaveChanges();
            }
        }
    }
}
