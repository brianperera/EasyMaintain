namespace EasyMaintain.SecurityWebAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyMaintain.SecurityWebAPI.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EasyMaintain.SecurityWebAPI.AuthContext";
        }

        protected override void Seed(EasyMaintain.SecurityWebAPI.AuthContext context)
        {
            //  This method will be called after migrating to the latest version.


            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuthContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AuthContext()));

            //manager.Create()

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
