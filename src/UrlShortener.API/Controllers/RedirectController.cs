using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Features.Urls.Queries.ResolveShortCode;

namespace UrlShortener.API.Controllers;

[ApiController]
public class RedirectController : ControllerBase
{
    private readonly IMediator _mediator;

    public RedirectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/{shortCode}")]
    public async Task<IActionResult> RedirectToOriginal(
        string shortCode,
        CancellationToken cancellationToken)
    {
        var originalUrl = await _mediator.Send(new ResolveShortCodeQuery(shortCode), cancellationToken);
        return Redirect(originalUrl);
    }
}
