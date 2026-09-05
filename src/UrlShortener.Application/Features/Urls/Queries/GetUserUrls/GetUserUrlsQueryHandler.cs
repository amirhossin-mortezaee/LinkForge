using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public class GetUserUrlsQueryHandler
    : IRequestHandler<GetUserUrlsQuery, PagedResult<ShortUrlDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUserUrlsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<ShortUrlDto>> Handle(
        GetUserUrlsQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.ShortUrls
            .AsQueryable()
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(x =>
                x.OriginalUrl.Contains(request.Search) ||
                x.ShortCode.Contains(request.Search));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        query = request.SortBy?.ToLower() switch
        {
            "originalurl" => request.SortDescending
                ? query.OrderByDescending(x => x.OriginalUrl)
                : query.OrderBy(x => x.OriginalUrl),
            "clickcount" => request.SortDescending
                ? query.OrderByDescending(x => x.ClickCount)
                : query.OrderBy(x => x.ClickCount),
            _ => request.SortDescending
                ? query.OrderByDescending(x => x.CreatedAt)
                : query.OrderBy(x => x.CreatedAt)
        };

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
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

        return new PagedResult<ShortUrlDto>
        {
            Items = items,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}