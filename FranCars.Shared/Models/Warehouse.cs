using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranCars.Shared.Models
{
    public class Warehouse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "cars")]
        public Cars Cars { get; set; }
    }
}
