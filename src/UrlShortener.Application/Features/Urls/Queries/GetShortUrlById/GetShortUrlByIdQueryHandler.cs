using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetShortUrlById;

public class GetShortUrlByIdQueryHandler
    : IRequestHandler<GetShortUrlByIdQuery, ShortUrlDto>
{
    private readonly IApplicationDbContext _context;

    public GetShortUrlByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrlDto> Handle(
        GetShortUrlByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.ShortUrls
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new ShortUrlNotFoundException(request.Id);

        return new ShortUrlDto
        {
            Id = entity.Id,
            OriginalUrl = entity.OriginalUrl,
            ShortCode = entity.ShortCode,
            ClickCount = entity.ClickCount,
            CreatedAt = entity.CreatedAt,
            ExpiresAt = entity.ExpiresAt,
            IsActive = entity.IsActive
        };
    }
}