using Microsoft.AspNetCore.Identity;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Infrastructure.Identity;

namespace UrlShortener.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(bool Succeeded, Guid UserId, IEnumerable<string> Errors)> RegisterAsync(string email, string password)
    {
        var user = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        return (result.Succeeded, user.Id, result.Errors.Select(e => e.Description));
    }

    public async Task<Guid?> ValidateCredentialsAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return null;

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
        if (!isPasswordValid)
            return null;

        return user.Id;
    }
}