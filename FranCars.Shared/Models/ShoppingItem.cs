using System.ComponentModel.DataAnnotations.Schema;

namespace FranCars.Shared.Models
{
    public class ShoppingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
