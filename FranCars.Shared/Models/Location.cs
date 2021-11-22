using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranCars.Shared.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "long")]
        public double Longitude { get; set; }

        [ForeignKey("Warehouses")]
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
