using FranCars.Shared.Models;

namespace FranCars.Api.Data.Repositories
{
    public interface IShoppingItemRepository
    {
        ShoppingItem Add(ShoppingItem shoppingItem);
    }
}
