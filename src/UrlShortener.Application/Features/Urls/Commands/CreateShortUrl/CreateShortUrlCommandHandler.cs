using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Interfaces;

namespace UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;

public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IShortCodeGenerator _shortCodeGenerator;

    public CreateShortUrlCommandHandler(
        IApplicationDbContext context,
        IShortCodeGenerator shortCodeGenerator)
    {
        _context = context;
        _shortCodeGenerator = shortCodeGenerator;
    }

    public async Task<Guid> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
    {
        string shortCode;

        if (!string.IsNullOrWhiteSpace(request.CustomAlias))
        {
            var isTaken = await _context.ShortUrls
                .AnyAsync(x => x.ShortCode == request.CustomAlias, cancellationToken);

            if (isTaken)
            {
                throw new DuplicateShortCodeException(request.CustomAlias);
            }

            shortCode = request.CustomAlias;
        }
        else
        {
            shortCode = _shortCodeGenerator.GenerateUnique(
                length: 6,
                existsCheck: code => _context.ShortUrls.Any(x => x.ShortCode == code));
        }

        var shortUrl = ShortUrl.Create(
            originalUrl: request.OriginalUrl,
            shortCode: shortCode,
            userId: request.UserId,
            expiresAt: request.ExpiresAt);

        _context.ShortUrls.Add(shortUrl);
        await _context.SaveChangesAsync(cancellationToken);

        return shortUrl.Id;
    }
}
