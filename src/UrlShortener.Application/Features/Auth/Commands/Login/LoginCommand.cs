using MediatR;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Guid>;