using System.Text.Json.Serialization;

namespace FranCars.Shared.Data
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("long")]
        public string Longitude { get; set; }
    }
}
