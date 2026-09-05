using MediatR;

namespace UrlShortener.Application.Features.Urls.Queries.ResolveShortCode;

public record ResolveShortCodeQuery(string ShortCode) : IRequest<string>;
