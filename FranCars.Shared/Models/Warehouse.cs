using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Models
{
    public class Warehouse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("_id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("cars")]
        public Cars Cars { get; set; }
    }
}
