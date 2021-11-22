using FranCars.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FranCars.Api.Data.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository (AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _context.Warehouses.Include(i => i.Location).Include(i => i.Cars).ThenInclude(i => i.Vehicles);
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            return _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
        }
    }
}
