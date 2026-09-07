using MediatR;

namespace UrlShortener.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<Guid>;