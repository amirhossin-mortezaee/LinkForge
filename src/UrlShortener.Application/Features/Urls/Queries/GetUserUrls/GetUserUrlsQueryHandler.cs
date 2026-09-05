using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public class GetUserUrlsQueryHandler
    : IRequestHandler<GetUserUrlsQuery, List<ShortUrlDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUserUrlsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ShortUrlDto>> Handle(
        GetUserUrlsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.ShortUrls
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new ShortUrlDto
            {
                Id = x.Id,
                OriginalUrl = x.OriginalUrl,
                ShortCode = x.ShortCode,
                ClickCount = x.ClickCount,
                CreatedAt = x.CreatedAt,
                ExpiresAt = x.ExpiresAt,
                IsActive = x.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}