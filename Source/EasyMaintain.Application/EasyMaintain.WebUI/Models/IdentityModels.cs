using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyMaintain.WebUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<EasyMaintain.WebUI.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.WebUI.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.WebUI.Models.Manufacturer> Manufacturers { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.WebUI.Models.EngineType> EngineTypes { get; set; }

        public System.Data.Entity.DbSet<EasyMaintain.WebUI.Models.AircraftModel> AircraftModels { get; set; }
    }
}