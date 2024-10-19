using ExamManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Repository
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"server=localhost;port=3306;user=root;password=Jyoti#1417;database=net";
            optionsBuilder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.title).IsRequired();
                entity.Property(e=>e.releaseDate).IsRequired();
                entity.Property(e=>e.description).IsRequired();
                entity.Property(e=>e.actorName).IsRequired();   


            });
            modelBuilder.Entity<Movie>().ToTable("movies");
        }
    }
}
