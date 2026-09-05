using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.Urls.Commands.UpdateShortUrl;

public class UpdateShortUrlCommandHandler : IRequestHandler<UpdateShortUrlCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateShortUrlCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateShortUrlCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ShortUrls
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new ShortUrlNotFoundException(request.Id);

        if (request.IsActive.HasValue)
        {
            if (request.IsActive.Value)
                entity.Activate();
            else
                entity.Deactivate();
        }

        if (request.ExpiresAt.HasValue)
        {
            entity.UpdateExpiration(request.ExpiresAt);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}