using Microsoft.EntityFrameworkCore;
using sample.Models;


namespace sample.Data
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }
        public DbSet<Admins> admins { get; set; }
        public DbSet<Quizzes> quizzes { get; set; }
        public DbSet<Questions> questions { get; set; } 
        public DbSet<Categories> categories { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<QuizResults> quizresults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.admin_id);
                entity.Property(e => e.first_name).IsRequired();
                entity.Property(e => e.last_name).IsRequired();
                entity.Property(e => e.username).IsRequired();
                entity.Property(e => e.password).IsRequired();
                entity.Property(e => e.is_active).IsRequired();
            });
            modelBuilder.Entity<Admins>().ToTable("admins");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.cat_id);
                entity.Property(e => e.description).IsRequired();
                entity.Property(e => e.title).IsRequired();
                // Configuring the relationship
                entity.HasOne<Admins>()
                      .WithMany()
                      .HasForeignKey(c => c.admin_id)
                      .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Categories>().ToTable("categories");

            modelBuilder.Entity<Quizzes>(entity =>
            {
                entity.HasKey(e => e.quiz_id);
                entity.Property(e => e.description).IsRequired();
                entity.Property(e => e.isActive).IsRequired();
                entity.Property(e => e.maxMarks).IsRequired();
                entity.Property(e => e.num_of_questions).IsRequired();
                entity.Property(e => e.title).IsRequired();
                entity.HasOne<Categories>().WithMany().HasForeignKey(c => c.cat_id).OnDelete(DeleteBehavior.Cascade); 
            });
            modelBuilder.Entity<Quizzes>().ToTable("quizzes");

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e=>e.ques_id);
                entity.Property(e => e.answer).IsRequired();
                entity.Property(e => e.question).IsRequired();
                entity.Property(e => e.option1).IsRequired();
                entity.Property(e => e.option2).IsRequired();
                entity.Property(e => e.option3).IsRequired();
                entity.Property(e => e.option4).IsRequired();
                entity.HasOne<Quizzes>().WithMany().HasForeignKey(c => c.quiz_id).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Questions>().ToTable("questions");

            modelBuilder.Entity<Users>(entity =>
            {
entity.HasKey(e=>e.user_id);    
entity.Property(e=>e.firstName).IsRequired();
                entity.Property(e => e.lastName).IsRequired();
                entity.Property(e => e.isActive).IsRequired();
                entity.Property(e => e.password).IsRequired();
                entity.Property(e => e.phoneNumber).IsRequired();
                entity.Property(e => e.username).IsRequired();
            });
            modelBuilder.Entity<Users>().ToTable("users");
        }
    }
}
