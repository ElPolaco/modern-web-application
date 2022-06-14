namespace TNAI.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TNAI.Model.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TNAI.Model.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Entitites.Category()
                {
                    Id = 1,
                    Name = "Motoryzacja"
                });
                context.Products.Add(new Entitites.Product()
                {
                    Name = "Rower",
                    Price = 30,
                    CategoryId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
