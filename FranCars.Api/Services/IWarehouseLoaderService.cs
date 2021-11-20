using System.Collections.Generic;
using FranCars.Shared.Models;

namespace FranCars.Api.Services
{
    public interface IWarehouseLoaderService
    {
        List<Warehouse> LoadFromFile();
    }
}
