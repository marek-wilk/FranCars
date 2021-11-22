using FranCars.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FranCars.Api.Services
{
    public class WarehouseLoaderService : IWarehouseLoaderService
    {
        //Loads data from json and deserializes it
        public List<Warehouse> LoadFromFile()
        {
            var path = $"{Environment.CurrentDirectory}/warehouses.json";
            List<Warehouse> warehouses;

            var json = File.ReadAllText(path);

            warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(json);

            return warehouses;
        }
    }
}
