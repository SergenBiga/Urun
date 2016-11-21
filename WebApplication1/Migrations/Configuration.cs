namespace WebApplication1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

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

            //Admin rolü
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var rstore = new RoleStore<IdentityRole>(context);
                var rmanager = new RoleManager<IdentityRole>(rstore);
                var role = new IdentityRole { Name = "Admin" };
                rmanager.Create(role);
            }
            if (!context.Users.Any(x => x.Email == "d@d.com"))
            {
                //Kullanýcý
                var kstore = new UserStore<ApplicationUser>(context);
                var kmanager = new UserManager<ApplicationUser>(kstore);
                var user = new ApplicationUser { UserName = "d@d.com", Email = "d@d.com" };
                kmanager.Create(user, "123456");
                kmanager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
