using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonPropertyName("shoppingCart")]
        public ShoppingCart ShoppingCart { get; set; }
    }
}
