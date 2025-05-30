

using Microsoft.EntityFrameworkCore;
using Migration_Task.Data.Entities;
using MigrationTask.Data.Seeds;

namespace Migration_Task.Data
{
    public class MigrationTaskContext : DbContext
    {
        public MigrationTaskContext(DbContextOptions<MigrationTaskContext> options) : base(options)
        { }

        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Category> Categories => Set<Category>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CategoriesSeed();
            modelBuilder.ProductsSeed();
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
