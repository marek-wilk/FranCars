using FranCars.Shared.ViewModels;

namespace FranCars.Api.Services
{
    public interface IVehicleViewModelFactory
    {
        VehicleViewModel CreateVehicleViewModel(int vehicleId);
    }
}
