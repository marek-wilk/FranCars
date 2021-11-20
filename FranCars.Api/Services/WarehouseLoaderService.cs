using FranCars.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FranCars.Api.Services
{
    public class WarehouseLoaderService : IWarehouseLoaderService
    {
        public List<Warehouse> LoadFromFile()
        {
            var path = $"{Environment.CurrentDirectory}/warehouses.json";
            List<Warehouse> warehouses;
            
            using (var file = File.OpenText(path))
            {
                var serializer = new JsonSerializer();
                warehouses = (List<Warehouse>) serializer.Deserialize(file, typeof(List<Warehouse>));
            }
            return warehouses;
        }
    }
}
