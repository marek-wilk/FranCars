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

        public VehicleViewModel CreateVehicleViewModel(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
            var warehouse = _warehouseRepository.GetWarehouses()
                .FirstOrDefault(w => w.Cars.Vehicles.Contains(vehicle));

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
