using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
