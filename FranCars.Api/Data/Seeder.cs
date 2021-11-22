using FranCars.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FranCars.Api.Data
{
    public static class Seeder
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
            }

            //Seeding initial data
            if (!context.Warehouses.Any())
            {
                var data = new WarehouseLoaderService().LoadFromFile();
                context.AddRange(data);
                context.SaveChanges();
            }
        }
    }
}
