using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Domain.Entities.Questions;
using AzmonNew.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace Azmon.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionPacks> QuestionPacks { get; set; }

        public Task<int> SaveChangeAsync(bool acceptAllChangesOnSuccessl, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            SeedData(modelBuilder);
            modelBuilder.Entity<Question>().HasIndex(u => u.QuestionText).IsUnique();
            ApplyQueryFilter(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "C#" });
        }


        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<QuestionPacks>().HasQueryFilter(p => !p.IsRemoved);

        }
    }
}
