using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(bool Succeeded, Guid UserId, IEnumerable<string> Errors)> RegisterAsync(string email, string password);
    Task<(Guid Id, string Email)?> ValidateCredentialsAsync(string email, string password);
    Task<(Guid Id, string Email)?> FindUserByIdAsync(Guid userId);
    Task<(Guid Id, string Email)?> FindUserByEmailAsync(string email);
}