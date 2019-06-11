namespace MyCurrencyPocketbook.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyCurrencyPocketbook.Models;
    using MyCurrencyPocketbook.Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyCurrencyPocketbook.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MyCurrencyPocketbook.Models.ApplicationDbContext";
        }

        protected override void Seed(MyCurrencyPocketbook.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(t=>t.UserName == "admin@none.com"))
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@none.com" };
                userManager.Create(user, "Pp123*");

                var service = new PocketAccountService(context);
                service.CreatePocketAccount("admin", "user", user.Id, 7730);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
