using FranCars.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FranCars.Api.Data.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository (AppDbContext context)
        {
            _context = context;
        }

        //Get all warehouses with all dependant objects from one-to-one relationship
        //I need to do this that way to access Cars and Location, when creating VehicleViewModel
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
