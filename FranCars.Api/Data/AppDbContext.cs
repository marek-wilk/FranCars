using FranCars.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FranCars.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
