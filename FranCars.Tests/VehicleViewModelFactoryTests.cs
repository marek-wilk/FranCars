using FluentAssertions;
using FranCars.Api.Data.Repositories;
using FranCars.Api.Services;
using FranCars.Shared.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FranCars.Tests
{
    public class VehicleViewModelFactoryTests
    {

        [Fact]
        public void Should_Create_Vehicle_View_Model()
        {
            // Arrange
            var vehicleRepository = new Mock<IVehicleRepository>();
            var warehouseRepository = new Mock<IWarehouseRepository>();
            var vehicleId = 13;
            var vehicle = CreateVehicleDummyData(vehicleId);
            var warehouses = CreateWarehousesDummyData();

            vehicleRepository.Setup(_ => _.GetVehicleById(vehicleId)).Returns(vehicle);
            warehouseRepository.Setup(_ => _.GetWarehouses()).Returns(warehouses);

            IVehicleViewModelFactory
                sut = new VehicleViewModelFactory(vehicleRepository.Object, warehouseRepository.Object);

            // Act
            var vm = sut.CreateVehicleViewModel(vehicleId);

            // Assert
            vm.Should().NotBeNull();
            vm.Latitude.Should().Be(warehouses[2].Location.Latitude);
            vm.Longitude.Should().Be(warehouses[2].Location.Longitude);
            vm.LocationName.Should().Be(warehouses[2].Cars.Location);
            vm.WarehouseName.Should().Be(warehouses[2].Name);
            vm.Model.Should().Be(vehicle.Model);
            vm.Make.Should().Be(vehicle.Make);
            vm.YearModel.Should().Be(vehicle.YearModel);
            vm.Price.Should().Be(vehicle.Price);
        }

        private Vehicle CreateVehicleDummyData(int id)
        {
            return new Vehicle
            {
                VehicleId = id,
                Make = $"Volvo{id}",
                Model = $"85{id}",
                Price = 1000*id,
                YearModel = 2000 + id
            };
        }

        private List<Warehouse> CreateWarehousesDummyData()
        {
            return new List<Warehouse>
            {
                new Warehouse
                {
                    Id = 1,
                    Cars = new Cars
                    {
                        Location = "Spain",
                        Vehicles = new List<Vehicle>
                        {
                            CreateVehicleDummyData(1),
                            CreateVehicleDummyData(2),
                            CreateVehicleDummyData(3),
                            CreateVehicleDummyData(4),
                            CreateVehicleDummyData(5),
                        }
                    },
                    Location = new Location
                    {
                        Latitude = 1.000,
                        Longitude = 2.000
                    },
                    Name = "A"
                },
                new Warehouse
                {
                    Id = 2,
                    Cars = new Cars
                    {
                        Location = "Antarctica",
                        Vehicles = new List<Vehicle>
                        {
                            CreateVehicleDummyData(6),
                            CreateVehicleDummyData(7),
                            CreateVehicleDummyData(8),
                            CreateVehicleDummyData(9),
                            CreateVehicleDummyData(10),
                        }
                    },
                    Location = new Location
                    {
                        Latitude = 11.000,
                        Longitude = 12.000
                    },
                    Name = "B"
                },
                new Warehouse
                {
                    Id = 3,
                    Cars = new Cars
                    {
                        Location = "North Pole (Santa Claus Domain)",
                        Vehicles = new List<Vehicle>
                        {
                            CreateVehicleDummyData(11),
                            CreateVehicleDummyData(12),
                            CreateVehicleDummyData(13),
                            CreateVehicleDummyData(14),
                            CreateVehicleDummyData(15),
                        }
                    },
                    Location = new Location
                    {
                        Latitude = 111.000,
                        Longitude = 112.000
                    },
                    Name = "C"
                }
            };
        }
    }
}
