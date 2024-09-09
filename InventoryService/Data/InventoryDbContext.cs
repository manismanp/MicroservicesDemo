using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { Id = 1, Name = "ProductA", Stock = 100 },
                new InventoryItem { Id = 2, Name = "ProductB", Stock = 200 }
            );
        }
    }

}
