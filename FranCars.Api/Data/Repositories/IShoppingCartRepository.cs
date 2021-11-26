using FranCars.Shared.Models;

namespace FranCars.Api.Data.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetByUserId(int userId);

        void Update(ShoppingCart shoppingCart);
    }
}
