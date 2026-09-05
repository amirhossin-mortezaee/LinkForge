using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;

namespace UrlShortener.API.Controllers;

[ApiController]
[Route("api/urls")]
public class UrlsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UrlsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateShortUrlCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }
        catch (DuplicateShortCodeException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
        }
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id) => Ok();
}
