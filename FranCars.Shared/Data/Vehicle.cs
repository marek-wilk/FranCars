using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Data
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("_id")]
        public int Id { get; set; }

        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }
        
        [JsonPropertyName("year_model")]
        public string YearModel { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("licensed")]
        public bool Licensed { get; set; }

        [JsonPropertyName("date_added")]
        public string DateAdded { get; set; }
    }
}
