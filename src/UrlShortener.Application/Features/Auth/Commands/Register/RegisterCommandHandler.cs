using MediatR;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var (succeeded, userId, errors) = await _identityService.RegisterAsync(request.Email, request.Password);

        if (!succeeded)
            throw new RegistrationFailedException(string.Join("; ", errors));

        return userId;
    }
}