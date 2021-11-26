using System.Text.Json.Serialization;

namespace FranCars.Shared.Dtos
{
    public class ProductItemDto
    {
        [JsonPropertyName("id")]
        public int UserId { get; set; }

        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
