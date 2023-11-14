using Infrastructure.Jwt.Interfaces;

namespace Infrastructure.Jwt;

public class JwtSettings : IJwtSettings
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string SecretKey { get; set; }
    public int ExpirationInMinutes { get; set; }
}