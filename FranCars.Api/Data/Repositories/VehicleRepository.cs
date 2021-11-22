using FranCars.Shared.Models;
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

        //Get all vehicles from database
        //I used IEnumarable because we can use deferred LinQ methods like Where() or Select()
        //Which boosts performance for big databases, maybe not exactly for this one though.
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Vehicles;
        }

        public Vehicle GetVehicleById(int id)
        {
            return _context.Vehicles.First(v => v.VehicleId == id);
        }
    }
}
