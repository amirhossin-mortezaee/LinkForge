using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Common.Exceptions;
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
        try
        {
            var originalUrl = await _mediator.Send(new ResolveShortCodeQuery(shortCode), cancellationToken);
            return Redirect(originalUrl);
        }
        catch (ShortUrlNotFoundException)
        {
            return NotFound();
        }
        catch (ShortUrlNotAvailableException)
        {
            return StatusCode(410); // Gone — لینک وجود دارد ولی دیگر در دسترس نیست
        }
    }
}
