using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Urls.Queries.ResolveShortCode;

public class ResolveShortCodeQueryHandler : IRequestHandler<ResolveShortCodeQuery, string>
{
    private readonly IApplicationDbContext _context;

    public ResolveShortCodeQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(ResolveShortCodeQuery request, CancellationToken cancellationToken)
    {
        var shortUrl = await _context.ShortUrls
            .FirstOrDefaultAsync(x => x.ShortCode == request.ShortCode, cancellationToken);

        if (shortUrl is null)
        {
            throw new ShortUrlNotFoundException(request.ShortCode);
        }

        if (!shortUrl.IsActive || shortUrl.IsExpired())
        {
            throw new ShortUrlNotAvailableException(request.ShortCode);
        }

        shortUrl.RegisterClick();
        await _context.SaveChangesAsync(cancellationToken);

        return shortUrl.OriginalUrl;
    }
}
