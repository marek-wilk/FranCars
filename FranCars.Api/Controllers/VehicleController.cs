using FranCars.Api.Data.Repositories;
using FranCars.Shared.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FranCars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetVehicles();
        }
    }
}
