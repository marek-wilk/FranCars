using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FranCars.Shared.Models
{
    public class ShoppingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonIgnore]
        [ForeignKey("ShoppingCarts")]
        public int ShoppingCartId { get; set; }
    }
}
