using FranCars.Api.Data.Repositories;
using FranCars.Shared.ViewModels;
using System.Linq;

namespace FranCars.Api.Services
{
    public class VehicleViewModelFactory : IVehicleViewModelFactory
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public VehicleViewModelFactory(IVehicleRepository vehicleRepository, IWarehouseRepository warehouseRepository)
        {
            _vehicleRepository = vehicleRepository;
            _warehouseRepository = warehouseRepository;
        }

        //Creates VehicleViewModel used in Details component
        public VehicleViewModel CreateVehicleViewModel(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);

            //Finding warehouse in which vehicle with corresponding Id is stored
            //I used Exists instead of Contains because with Contains test was not passing
            //I am not sure if it was not due to Mock, but I'd like to know why Contains()
            //Work when app is running and why it is not working during unit tests
            var warehouse = _warehouseRepository
                .GetWarehouses()
                .ToList()
                .FirstOrDefault(w => w.Cars.Vehicles
                    .Exists(x => x.VehicleId == vehicleId));

            var vehicleViewModel = new VehicleViewModel
            {
                Make = vehicle.Make,
                Model = vehicle.Model,
                YearModel = vehicle.YearModel,
                Price = vehicle.Price,
                LocationName = warehouse.Cars.Location,
                Longitude = warehouse.Location.Longitude,
                Latitude = warehouse.Location.Latitude,
                WarehouseName = warehouse.Name
            };

            return vehicleViewModel;
        }
    }
}
