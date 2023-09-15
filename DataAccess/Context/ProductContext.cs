using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Context
{
    public class ProductContext : DbContext
    {

        public ProductContext()
        {
                
        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = VendingMachineRemoteDB; Trusted_Connection = True; ");

        }
        public DbSet<Product> Product { get; set; }

        public DbSet<DispensedProduct> DispensedProduct { get; set; }

    }
}
