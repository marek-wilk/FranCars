using FranCars.Shared.Data;
using System.Collections.Generic;

namespace FranCars.Api.Services
{
    public interface IWarehouseLoaderService
    {
        List<Warehouse> LoadFromFile();
    }
}
