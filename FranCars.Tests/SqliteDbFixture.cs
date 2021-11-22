using FranCars.Api.Data;
using FranCars.Api.Data.Repositories;
using FranCars.Api.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace FranCars.Tests
{
    public class SqliteDbFixture : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        public WarehouseRepository WarehouseRepository { get; private set; }
        public VehicleRepository VehicleRepository { get; private set; }
        public AppDbContext Context { get; private set; }

        public SqliteDbFixture()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;
            Context = new AppDbContext(options);
            Context.Database.EnsureCreated();
            var data = new WarehouseLoaderService().LoadFromFile();
            Context.AddRange(data);
            Context.SaveChanges();

            WarehouseRepository = new WarehouseRepository(Context);
            VehicleRepository = new VehicleRepository(Context);
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
