using MediatR;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public record GetUserUrlsQuery : IRequest<List<ShortUrlDto>>;