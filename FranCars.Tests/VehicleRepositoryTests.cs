using FluentAssertions;
using FranCars.Shared.Models;
using System.Linq;
using Xunit;

namespace FranCars.Tests
{
    public class VehicleRepositoryTests : IClassFixture<SqliteDbFixture>
    {
        private readonly SqliteDbFixture _fixture;

        public VehicleRepositoryTests(SqliteDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Get_All_Vehicles_From_Database()
        {
            var vehicles = _fixture.VehicleRepository.GetVehicles().ToList();
            vehicles.Should().HaveCount(80);
        }

        [Fact]
        public void Should_Return_Vehicle_With_Corresponding_Id()
        {
            var vehicle = _fixture.VehicleRepository.GetVehicleById(1);
            vehicle.VehicleId.Should().Be(1);
            vehicle.Should().BeOfType(typeof(Vehicle));
        }
    }
}
