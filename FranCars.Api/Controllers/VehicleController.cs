using FranCars.Api.Data.Repositories;
using FranCars.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public List<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetVehicles().OrderBy(x => x.DateAdded).ToList();
        }
    }
}
