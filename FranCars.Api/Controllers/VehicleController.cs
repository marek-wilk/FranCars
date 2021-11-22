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


        //Get all vehicles from database using repository
        [HttpGet]
        public List<Vehicle> GetVehicles()
        {
            var orderedVehicles = _vehicleRepository.GetVehicles().OrderBy(x => x.DateAdded).ToList();
            return orderedVehicles;
        }

        //returns VehicleViewModel used in Details component to check details
        /*This is not how it should be done according to good practices and REST,
        I know that, yet due to simplicity of the application I decided to do it in shorter, easier way.
        Of course I'm aware this makes this code not re-usable and case-specific which is way
        normally I wouldn't do that.*/
        [HttpGet("{id}")]
        public VehicleViewModel GetVehicleViewModel(int id)
        {
            return _vehicleVmFactory.CreateVehicleViewModel(id);
        }
    }
}
