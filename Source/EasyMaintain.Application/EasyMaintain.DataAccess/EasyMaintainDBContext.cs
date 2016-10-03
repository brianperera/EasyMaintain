using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EasyMaintain.DataAccess.Models;
//using EasyMaintain.Business;
using EasyMaintain.DTO;

namespace EasyMaintain.DataAccess
{
   public class EasyMaintainDBContext : DbContext
    {
        static EasyMaintainDBContext()
        {
            Database.SetInitializer<EasyMaintainDBContext>(new CreateDatabaseIfNotExists<EasyMaintainDBContext>());
        }

        public EasyMaintainDBContext() : base("EasyMaintainDBTest")
        {

        }
        public DbSet<AircraftModel> AircraftModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Manufacturer> Manufactureres { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Crew> Crews { get; set; }

        public DbSet<MaintenanceChecks> MaintenanceChecks { get; set; }

        public DbSet<ComponentWork> ComponentWorks { get; set; }

        public DbSet<DeliveryDetails> Deliveries { get; set; }
    }
}
