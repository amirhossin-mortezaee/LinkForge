using MediatR;

namespace UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;

public record CreateShortUrlCommand(
    string OriginalUrl,
    string? CustomAlias,
    DateTime? ExpiresAt,
    Guid? UserId
) : IRequest<Guid>;
