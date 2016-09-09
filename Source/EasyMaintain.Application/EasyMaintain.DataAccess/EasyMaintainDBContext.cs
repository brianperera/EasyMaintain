using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess.Models;

namespace EasyMaintain.DataAccess
{
    class EasyMaintainDBContext : DbContext
    {

        public EasyMaintainDBContext() : base()
        {

        }


        public DbSet<AircraftModel> AircraftModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<Manufacturer> Manufactureres { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Crew> Crews { get; set; }

        public DbSet<MaintenanceChecks> MaintenanceChecks { get; set; }
    }
}
