using FranCars.Shared.Data;
using System.Collections.Generic;

namespace FranCars.Api.Data.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();

        Vehicle GetVehicleById(int id);
    }
}
