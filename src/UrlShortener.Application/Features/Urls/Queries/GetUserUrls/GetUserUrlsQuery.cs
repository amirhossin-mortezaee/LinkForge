using MediatR;
using UrlShortener.Application.Common.Models;
using UrlShortener.Domain.Common;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public record GetUserUrlsQuery(
    int Page = 1,
    int PageSize = ShortUrlConstants.DefaultPageSize,
    string? Search = null,
    string? SortBy = null,
    bool SortDescending = false
) : IRequest<PagedResult<ShortUrlDto>>;