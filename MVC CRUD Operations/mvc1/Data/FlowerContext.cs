using Microsoft.EntityFrameworkCore;
using mvc1.Models;

namespace mvc1.Data
{
    public class FlowerContext : DbContext
    {
        public FlowerContext(DbContextOptions<FlowerContext> options)
            : base(options)
        {
        }

        public DbSet<Flowers> Flowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flowers>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.description).IsRequired();
                entity.Property(e => e.price).IsRequired();
                entity.Property(e => e.imageurl).IsRequired();
            });

            modelBuilder.Entity<Flowers>().ToTable("flowers");
        }
    }
}
