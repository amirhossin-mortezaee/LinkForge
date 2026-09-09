using MediatR;
using UrlShortener.Application.Features.Auth.Commands.Login;

namespace UrlShortener.Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<LoginResult>;
