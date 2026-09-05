using MediatR;

namespace UrlShortener.Application.Features.Urls.Commands.UpdateShortUrl;

public record UpdateShortUrlCommand(Guid Id, DateTime? ExpiresAt, bool? IsActive) : IRequest;