using Movie_Man.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Movie_Man.Repository
{
    public class MovieContext:DbContext

    {
        public DbSet<Movie> movie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStrng = @"server=localhost;user=root;password=Jyoti#1417;
             port=3306;database=net";
            optionsBuilder.UseMySQL(conStrng);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e=>e.id);
                entity.Property(e => e.title).IsRequired();
                entity.Property(e => e.releaseDate).IsRequired();
                entity.Property(e => e.description).IsRequired();
                entity.Property(e => e.actorName).IsRequired();

            });
            modelBuilder.Entity<Movie>().ToTable("movies");
        }

    }

}
