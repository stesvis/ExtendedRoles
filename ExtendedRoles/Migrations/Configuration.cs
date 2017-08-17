namespace ExtendedRoles.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExtendedRoles.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ExtendedRoles.Models.ApplicationDbContext>
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExtendedRoles.Models.ApplicationDbContext context)
        {
#if false
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            SeedRoles();

            SeedUsers();
#endif

            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating
            // duplicate seed data. E.g.
            //
            // context.People.AddOrUpdate( p => p.FullName, new Person { FullName = "Andrew Peters"
            // }, new Person { FullName = "Brice Lambson" }, new Person { FullName = "Rowan Miller" } );
        }

        private void SeedRoles()
        {
            try
            {
                if (!roleManager.RoleExists("SuperAdmin"))
                {
                    roleManager.Create(new IdentityRole("SuperAdmin"));
                }

                if (!roleManager.RoleExists("Manager"))
                {
                    roleManager.Create(new IdentityRole("Manager"));
                }

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Driver"))
                {
                    roleManager.Create(new IdentityRole("Driver"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SeedRoles", ex);
            }
        }

        private void SeedUsers()
        {
            SeedUser("superadmin", "SuperAdmin");
            SeedUser("manager", "Manager");
            SeedUser("admin", "Admin");
            SeedUser("driver", "Driver");
        }

        private void SeedUser(string username, string rolename)
        {
            ApplicationUser user = userManager.FindByName(username);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = username,
                    Email = $"{username}@levitica.ca",
                    EmailConfirmed = false,
                };

                IdentityResult userResult = userManager.Create(user, "test123");

                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, rolename);
                }
            }
        }
    }
}