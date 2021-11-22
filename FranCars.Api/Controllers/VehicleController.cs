using FranCars.Api.Data.Repositories;
using FranCars.Api.Services;
using FranCars.Shared.Models;
using FranCars.Shared.ViewModels;
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
        private readonly IVehicleViewModelFactory _vehicleVmFactory;

        public VehicleController(IVehicleRepository vehicleRepository, IVehicleViewModelFactory vehicleVmFactory)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleVmFactory = vehicleVmFactory;
        }

        [HttpGet]
        public List<Vehicle> GetVehicles()
        {
            var orderedVehicles = _vehicleRepository.GetVehicles().OrderBy(x => x.DateAdded).ToList();
            return orderedVehicles;
        }

        [HttpGet("{id}")]
        public VehicleViewModel GetVehicleViewModel(int id)
        {
            return _vehicleVmFactory.CreateVehicleViewModel(id);
        }
    }
}
