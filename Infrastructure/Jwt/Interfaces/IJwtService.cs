namespace Infrastructure.Jwt.Interfaces;

public interface IJwtService
{
    string GenerateToken(string userId, string userEmail, string[] roles);
}