using FranCars.Shared.Data;
using System.Collections.Generic;
using System.Linq;

namespace FranCars.Api.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _context.Vehicles.First(v => v.Id == id);
        }
    }
}
