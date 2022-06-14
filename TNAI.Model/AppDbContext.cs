using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNAI.Model.Configurations;
using TNAI.Model.Entitites;
using TNAI.Model.Identity;

namespace TNAI.Model
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<Category> Categories { get; set; } 
        public AppDbContext() : base("AppConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
