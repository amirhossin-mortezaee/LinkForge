using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Features.Auth.Commands.Login;
using UrlShortener.Application.Features.Auth.Commands.RefreshToken;
using UrlShortener.Application.Features.Auth.Commands.Register;

namespace UrlShortener.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userId = await _mediator.Send(command, cancellationToken);
        return Ok(new { userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(new { token = result.Token, expiresAt = result.ExpiresAt, refreshToken = result.RefreshToken });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
        [FromBody] RefreshTokenCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(new { token = result.Token, expiresAt = result.ExpiresAt, refreshToken = result.RefreshToken });
    }
}