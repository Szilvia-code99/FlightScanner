using API.Entities;

namespace API.Interfaces
{
    // Provides a token-based authentication service
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}