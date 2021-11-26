using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Models
{
    public class ShoppingCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("shoppingItems")]
        public List<ShoppingItem> ShoppingItems { get; set; }

        [JsonPropertyName("totalAmount")]
        public double TotalAmount => ShoppingItems?.Select(x => x.Price).Sum() ?? 0;

        [JsonPropertyName("numberOfItems")]
        public int NumberOfItems => ShoppingItems?.Count() ?? 0;

        [JsonIgnore]
        public User User { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
