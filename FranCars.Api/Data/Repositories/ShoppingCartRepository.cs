using FranCars.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FranCars.Api.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _context;

        public ShoppingCartRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetByUserId(int userId)
        {
            return _context.ShoppingCarts.Include(sc => sc.ShoppingItems).FirstOrDefault(x => x.UserId == userId);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
            _context.SaveChanges();
        }
    }
}
