using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Data
{
    public class Cars
    {
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
