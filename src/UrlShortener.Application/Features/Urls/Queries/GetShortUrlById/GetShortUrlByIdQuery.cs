using MediatR;
using UrlShortener.Application.Common.Models;

namespace UrlShortener.Application.Features.Urls.Queries.GetShortUrlById;

public record GetShortUrlByIdQuery(Guid Id) : IRequest<ShortUrlDto>;