using MediatR;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public record LoginResult(string Token, DateTime ExpiresAt, string RefreshToken);

public record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginResult>;