using FranCars.Shared.Models;
using System.Collections.Generic;

namespace FranCars.Api.Data.Repositories
{
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> GetWarehouses();

        Warehouse GetWarehouseById(int warehouseId);
    }
}
