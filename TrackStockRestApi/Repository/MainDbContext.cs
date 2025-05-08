using Microsoft.EntityFrameworkCore;
using TrackStockRestApi.Models;

namespace TrackStockRestApi.Repository
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  
                .WithMany(c => c.Products) 
                .HasForeignKey(p => p.CategoryId);  
        }
    }
}
