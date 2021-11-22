using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranCars.Shared.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
        
        [JsonProperty(PropertyName = "year_model")]
        public int YearModel { get; set; }

        public double Price { get; set; }

        public bool Licensed { get; set; }

        [JsonProperty(PropertyName = "date_added")]
        public DateTime DateAdded { get; set; }
    }
}
