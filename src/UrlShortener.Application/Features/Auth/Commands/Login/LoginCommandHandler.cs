using MediatR;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Guid>
{
    private readonly IIdentityService _identityService;

    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Guid> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userId = await _identityService.ValidateCredentialsAsync(request.Email, request.Password);

        if (userId is null)
            throw new InvalidCredentialsException();

        return userId.Value;
    }
}