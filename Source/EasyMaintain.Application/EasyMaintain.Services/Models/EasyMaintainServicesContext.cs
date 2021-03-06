﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyMaintain.Services.Models
{
    public class EasyMaintainServicesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EasyMaintainServicesContext() : base("name=EasyMaintainServicesContext")
        {
        }

        public System.Data.Entity.DbSet<EasyMaintain.Business.SparePart> SpareParts { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.Business.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.Business.Manufacturer> Manufacturers { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.Business.AircraftModel> AircraftModels { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.Business.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.Business.EngineType> EngineTypes { get; set; }
    }
}
