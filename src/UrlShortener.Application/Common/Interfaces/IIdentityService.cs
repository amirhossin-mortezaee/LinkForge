namespace UrlShortener.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(bool Succeeded, Guid UserId, IEnumerable<string> Errors)> RegisterAsync(string email, string password);
    Task<Guid?> ValidateCredentialsAsync(string email, string password);
}