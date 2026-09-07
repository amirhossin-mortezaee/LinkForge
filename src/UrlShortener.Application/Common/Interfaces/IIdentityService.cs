namespace UrlShortener.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(bool Succeeded, Guid UserId, IEnumerable<string> Errors)> RegisterAsync(string email, string password);
}