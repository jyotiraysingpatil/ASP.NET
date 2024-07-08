using Microsoft.EntityFrameworkCore;
using ECommerce_Flipkart.Models;


namespace ECommerce_Flipkart.Repository
{
    public class EStoreCollectionContextDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"server=localhost;port=3306;user=root; password=Jyoti#1417;database=net";
            optionsBuilder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set mapping of a table with poco
            //Relational       instance: Table
            //Object Oriented  instance: POCO Class
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.Imageurl).IsRequired();
                entity.Property(e => e.quantity).IsRequired();




            });
            modelBuilder.Entity<Product>().ToTable("products");
        }


    }

}
