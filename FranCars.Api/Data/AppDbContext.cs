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
    }
}
