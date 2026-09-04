using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ShortUrl> ShortUrls { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
