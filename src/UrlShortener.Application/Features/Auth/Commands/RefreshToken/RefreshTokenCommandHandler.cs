using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UrlShortener.Application.Common;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Features.Auth.Commands.Login;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Exceptions;

namespace UrlShortener.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResult>
{
    private readonly IApplicationDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IIdentityService _identityService;
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<RefreshTokenCommandHandler> _logger;

    public RefreshTokenCommandHandler(
        IApplicationDbContext context,
        ITokenService tokenService,
        IIdentityService identityService,
        IOptions<JwtSettings> jwtSettings,
        ILogger<RefreshTokenCommandHandler> logger)
    {
        _context = context;
        _tokenService = tokenService;
        _identityService = identityService;
        _jwtSettings = jwtSettings.Value;
        _logger = logger;
    }

    public async Task<LoginResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var storedToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken, cancellationToken);

        if (storedToken is null || !storedToken.IsActive)
        {
            _logger.LogWarning("تلاش برای استفاده از یک Refresh Token نامعتبر یا منقضی‌شده.");
            throw new InvalidRefreshTokenException();
        }

        var user = await _identityService.FindUserByIdAsync(storedToken.UserId);

        if (user is null)
        {
            _logger.LogError("Refresh Token معتبر بود ولی کاربر مربوطه ({UserId}) پیدا نشد.", storedToken.UserId);
            throw new InvalidRefreshTokenException();
        }

        var (newAccessToken, newExpiresAt) = _tokenService.GenerateAccessToken(user.Value.Id, user.Value.Email);

        storedToken.Revoke();

        var newRefreshTokenValue = _tokenService.GenerateRefreshToken();
        var newRefreshTokenExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);
        var newRefreshToken = global::UrlShortener.Domain.Entities.RefreshToken.Create(user.Value.Id, newRefreshTokenValue, newRefreshTokenExpiresAt);

        _context.RefreshTokens.Add(newRefreshToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new LoginResult(newAccessToken, newExpiresAt, newRefreshTokenValue);
    }
}
