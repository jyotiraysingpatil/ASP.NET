using Microsoft.EntityFrameworkCore;
using StudentManagement.Entities;

namespace StudentManagement.Repository
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get;   set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"server=localhost;port=3306;user=root;password=Jyoti#1417;database=net";
            optionsBuilder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e=>e.name).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.mobile_no).IsRequired();
                entity.Property(e => e.address).IsRequired();
                entity.Property(e => e.admission_date).IsRequired();
                entity.Property(e => e.fees).IsRequired();
                entity.Property(e => e.status).IsRequired();
            });
            modelBuilder.Entity<Student>().ToTable("students");
        }
    }
}
