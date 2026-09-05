using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Common.Models;
using UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;
using UrlShortener.Application.Features.Urls.Commands.DeleteShortUrl;
using UrlShortener.Application.Features.Urls.Commands.UpdateShortUrl;
using UrlShortener.Application.Features.Urls.Queries.GetShortUrlById;
using UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

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
    [ProducesResponseType(typeof(ShortUrlDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShortUrlDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetShortUrlByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResult<ShortUrlDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PagedResult<ShortUrlDto>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] bool sortDescending = false,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(
            new GetUserUrlsQuery(page, pageSize, search, sortBy, sortDescending),
            cancellationToken);
        return Ok(result);
    }

    public record UpdateShortUrlRequest(DateTime? ExpiresAt, bool? IsActive);

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateShortUrlRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateShortUrlCommand(id, request.ExpiresAt, request.IsActive);
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteShortUrlCommand(id), cancellationToken);
        return NoContent();
    }
}