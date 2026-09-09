using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UrlShortener.Application.Common;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly IApplicationDbContext _context;
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        IIdentityService identityService,
        ITokenService tokenService,
        IApplicationDbContext context,
        IOptions<JwtSettings> jwtSettings,
        ILogger<LoginCommandHandler> logger)
    {
        _identityService = identityService;
        _tokenService = tokenService;
        _context = context;
        _jwtSettings = jwtSettings.Value;
        _logger = logger;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityService.ValidateCredentialsAsync(request.Email, request.Password);

        if (user is null)
        {
            _logger.LogWarning("Failed login attempt for email {Email}", request.Email);
            throw new InvalidCredentialsException();
        }

        var (token, expiresAt) = _tokenService.GenerateAccessToken(user.Value.Id, user.Value.Email);

        var refreshTokenValue = _tokenService.GenerateRefreshToken();
        var refreshTokenExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);

        var refreshToken = global::UrlShortener.Domain.Entities.RefreshToken.Create(user.Value.Id, refreshTokenValue, refreshTokenExpiresAt);

        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new LoginResult(token, expiresAt, refreshTokenValue);
    }
}