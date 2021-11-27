using System.IdentityModel.Tokens.Jwt;

namespace FranCars.Api.Services
{
    public interface IJwtService
    {
        string Generate(int id);

        JwtSecurityToken Verify(string jwt);
    }
}
