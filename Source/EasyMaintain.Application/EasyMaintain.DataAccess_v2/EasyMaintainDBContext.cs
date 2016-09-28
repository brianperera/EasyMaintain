using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyMaintain.DataAccess_v2.Models;
using Microsoft.EntityFrameworkCore;


namespace EasyMaintain.DataAccess_v2
{
    public class EasyMaintainDBContext : DbContext
    {

        static EasyMaintainDBContext()
        {
           
        }
        public EasyMaintainDBContext(DbContextOptions<EasyMaintainDBContext> EasymaintainDatabase):base(EasymaintainDatabase)
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
