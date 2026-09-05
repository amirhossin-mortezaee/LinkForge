using MediatR;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public record GetUserUrlsQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    bool SortDescending = false
) : IRequest<PagedResult<ShortUrlDto>>;