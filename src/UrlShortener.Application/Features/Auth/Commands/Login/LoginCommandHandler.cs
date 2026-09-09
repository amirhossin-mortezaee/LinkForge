using MediatR;
using Microsoft.Extensions.Logging;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        IIdentityService identityService,
        ITokenService tokenService,
        ILogger<LoginCommandHandler> logger)
    {
        _identityService = identityService;
        _tokenService = tokenService;
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

        return new LoginResult(token, expiresAt);
    }
}