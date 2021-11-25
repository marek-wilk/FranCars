using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FranCars.Shared.Models
{
    public class ShoppingCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<ShoppingItem> ShoppingItems { get; set; }

        public double TotalAmount => ShoppingItems?.Select(x => x.Price).Sum() ?? 0;

        public int NumberOfItems => ShoppingItems?.Count() ?? 0;

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
