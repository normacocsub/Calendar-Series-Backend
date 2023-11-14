namespace Infrastructure.Jwt.Interfaces;

public interface IJwtSettings
{
    string Issuer { get; set; }
    string Audience { get; set; }
    string SecretKey { get; set; }
    int ExpirationInMinutes { get; set; }
}