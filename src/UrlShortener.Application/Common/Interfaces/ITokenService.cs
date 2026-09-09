namespace UrlShortener.Application.Common.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) GenerateAccessToken(Guid userId, string email);
    string GenerateRefreshToken();
}
