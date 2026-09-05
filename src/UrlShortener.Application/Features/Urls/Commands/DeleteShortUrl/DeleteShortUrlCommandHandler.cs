using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Urls.Commands.DeleteShortUrl;

public class DeleteShortUrlCommandHandler : IRequestHandler<DeleteShortUrlCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteShortUrlCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteShortUrlCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ShortUrls
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new ShortUrlNotFoundException(request.Id);

        // Soft Delete: Mark as inactive instead of hard deleting.
        // Reason: Click stats and link history are valuable for a URL Shortener;
        // physical deletion would permanently destroy this data.
        // If real deletion is needed later (e.g., GDPR), a separate HardDelete command can be added.
        entity.Deactivate();

        await _context.SaveChangesAsync(cancellationToken);
    }
}