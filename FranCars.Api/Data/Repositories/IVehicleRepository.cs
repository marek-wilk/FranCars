using FranCars.Shared.Models;
using System.Collections.Generic;

namespace FranCars.Api.Data.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();

        Vehicle GetVehicleById(int id);
    }
}
