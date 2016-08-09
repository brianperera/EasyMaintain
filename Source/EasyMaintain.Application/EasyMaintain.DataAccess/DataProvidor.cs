using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.DataAccess
{
    public class DataProvidor
    {
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
        public void AddSupplier(string supplierName, string emailAddress, string address, string contact,string description, string additionalData)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var supplier = db.Set<Supplier>();
                supplier.Add(new Supplier { SupplierName = supplierName, EmailAddress = emailAddress, Address =address, ContactDetails = contact, Description = description, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }

        public void AddManufacturer(string manufacturerName, string description, string additionalData)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var manufacturer = db.Set<Manufacturer>();
                manufacturer.Add(new Manufacturer { ManufacturerName = manufacturerName, Description = description, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }

        public void AddCategory(string categoryName, string additionalData)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var category = db.Set<Category>();
                category.Add(new Category { CategoryName = categoryName, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }

        public void AddEngineType(string engineTypeName, string additionalData)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var engineType = db.Set<EngineType>();
                engineType.Add(new EngineType { EngineTypeName = engineTypeName, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }

        public void AddAircraftModel(string aircraftModelname, string description, string additionalData, int categoryID, int engineTypeId, int manufacturerId, string imagepath)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var aircraftModel = db.Set<AircraftModel>();
                aircraftModel.Add(new AircraftModel { ModelName = aircraftModelname, CategoryID = categoryID, EngineTypeID = engineTypeId, ManufacturerID = manufacturerId, ImagePath = imagepath, Description = description, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }

        public void AddSparePart(string sparePartName, string description, string additionalData, int categoryID, string imagepath)
        {
            // insert
            using (var db = new EasyMaintainEntities())
            {
                var sparePart = db.Set<SparePart>();
                sparePart.Add(new SparePart { SparePartName = sparePartName, CategoryID = categoryID, ImagePath = imagepath, Description = description, AdditionalData = additionalData });

                db.SaveChanges();
            }
        }


        //---- Update Data
        public void UpdateSupplier(int supplierId ,string supplierName, string emailAddress, string address, string contact, string description, string additionalData)
        {
            // update
            using (var db = new EasyMaintainEntities())
            {
                var supplier = db.Suppliers.SingleOrDefault(s => s.SupplierID == supplierId);

                if(supplier != null)
                {
                    supplier.SupplierName = supplierName;
                    supplier.EmailAddress = emailAddress;
                    supplier.Address = address;
                    supplier.ContactDetails = contact;
                    supplier.Description = description;
                    supplier.AdditionalData = additionalData;
                }
                db.SaveChanges();
            }
        }

        public void UpdateManufacturer(int manufacturerId, string manufacturerName, string description, string additionalData)
        {
            // update
            using (var db = new EasyMaintainEntities())
            {
                var manufacturer = db.Manufacturers.SingleOrDefault(s => s.ManufacturerID == manufacturerId);

                if (manufacturer != null)
                {
                    manufacturer.ManufacturerName = manufacturerName;
                    manufacturer.Description = description;
                    manufacturer.AdditionalData = additionalData;
                }
                db.SaveChanges();
            }
        }

        public void UpdateCategory(int categoryId ,string categoryName)
        {
            // update
            using (var db = new EasyMaintainEntities())
            {
                var category = db.Categories.SingleOrDefault(s => s.CategoryID == categoryId);

                if (category != null)
                {
                    category.CategoryName = categoryName;
                }
                db.SaveChanges();
            }
        }

        public void UpdateEngineType(int engineTypeId, string engineTypeName, string additionalData)
        {
            // update
            using (var db = new EasyMaintainEntities())
            {
                var engineType = db.EngineTypes.SingleOrDefault(s => s.EngineTypeID == engineTypeId);

                if (engineType != null)
                {
                    engineType.EngineTypeName = engineTypeName;
                    engineType.AdditionalData = additionalData;
                }
                db.SaveChanges();
            }
        }

        public void UpdateAircraftModel(int aircraftModleId, string aircraftModelname, string description, string additionalData, int categoryID, int engineTypeId, int manufacturerId, string imagepath)
        {
            // update
            using (var db = new EasyMaintainEntities())
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
            }
        }

        public void UpdateSparePart(int sparePartId, string sparePartName, string description, string additionalData, int categoryID, string imagepath)
        {
            // update
            using (var db = new EasyMaintainEntities())
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
            }
        }


        //--- Delete Data
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
