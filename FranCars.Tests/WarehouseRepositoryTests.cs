using FluentAssertions;
using System.Linq;
using Xunit;

namespace FranCars.Tests
{
    public class WarehouseRepositoryTests : IClassFixture<SqliteDbFixture>
    {
        private readonly SqliteDbFixture _fixture;

        public WarehouseRepositoryTests(SqliteDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Return_All_Warehouses_From_Database_With_Their_Related_Objects()
        {
            var warehouses = _fixture.WarehouseRepository.GetWarehouses().ToList();
            warehouses.Should().HaveCount(4);
            warehouses[0].Location.Should().NotBeNull();
            warehouses[0].Cars.Should().NotBeNull();
            warehouses[0].Cars.Vehicles.Should().NotBeNull();
        }

        [Fact]
        public void Should_Return_Warehouse_With_Corresponding_Id()
        {
            var warehouse = _fixture.WarehouseRepository.GetWarehouseById(1);
            warehouse.Id.Should().Be(1);
        }
    }
}
