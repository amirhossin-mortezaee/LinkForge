using MediatR;

namespace UrlShortener.Application.Features.Urls.Commands.DeleteShortUrl;

public record DeleteShortUrlCommand(Guid Id) : IRequest;