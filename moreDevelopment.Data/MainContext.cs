using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
namespace moreDevelopment.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MainContext : DbContext
    {
        static MainContext()
        {
            Database.SetInitializer<MainContext>(null);
        }
        public MainContext() : base("Name=Context")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
      
        public DbSet<products> products { get; set; }
        public DbSet<invoices> invoices { get; set; }
        public DbSet<invoiceProducts> invoiceProducts { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mapping.productsMap());
           
            modelBuilder.Configurations.Add(new Mapping.invoicesMap());
            modelBuilder.Configurations.Add(new Mapping.invoiceProductsMap());
           
        }
    }
}

