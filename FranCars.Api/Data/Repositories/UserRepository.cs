using FranCars.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FranCars.Api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.ShoppingCart)
                .ThenInclude(sc => sc.ShoppingItems)
                .FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.ShoppingCart)
                .ThenInclude(sc => sc.ShoppingItems)
                .FirstOrDefault(u => u.Id == id);
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();

            return user;
        }
    }
}
