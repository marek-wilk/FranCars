using FranCars.Shared.Models;

namespace FranCars.Api.Data.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly AppDbContext _context;

        public ShoppingItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingItem Add(ShoppingItem shoppingItem)
        {
            _context.ShoppingItems.Add(shoppingItem);
            var shoppingItemId = _context.SaveChanges();
            shoppingItem.Id = shoppingItemId;
            return shoppingItem;
        }
    }
}
