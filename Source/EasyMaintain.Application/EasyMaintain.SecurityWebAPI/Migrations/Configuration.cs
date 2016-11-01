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

            var user = new ApplicationUser()
            {
                UserName = "superadmin",
                Email = "john.atm@outlook.com",
                EmailConfirmed = true,
                FirstName = "Donald",
                LastName = "Trump",
            };

            manager.Create(user, "donaldtrump1");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("superadmin");

            // manager.AddToRole(adminUser.Id, new string[] { "SuperAdmin", "Admin" }.ToString());
            manager.AddToRole(adminUser.Id, "SuperAdmin");
            //manager.AddToRole(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
            context.SaveChanges();
            base.Seed(context);
        }


    }

    }



