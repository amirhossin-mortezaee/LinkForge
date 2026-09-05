using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id) => Ok();
}
