using FranCars.Shared.Models;

namespace FranCars.Api.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByEmail(string email);

        User GetById(int id);

        User Create(User user);
    }
}
