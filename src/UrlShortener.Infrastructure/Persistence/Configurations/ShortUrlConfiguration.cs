using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Common;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Persistence.Configurations;

public class ShortUrlConfiguration : IEntityTypeConfiguration<ShortUrl>
{
    public void Configure(EntityTypeBuilder<ShortUrl> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.OriginalUrl)
            .IsRequired()
            .HasMaxLength(ShortUrlConstants.OriginalUrlMaxLength);

        builder.Property(x => x.ShortCode)
            .IsRequired()
            .HasMaxLength(ShortUrlConstants.ShortCodeMaxLength);

        builder.HasIndex(x => x.ShortCode).IsUnique();

        builder.HasIndex(x => x.UserId);

        builder.HasIndex(x => x.CreatedAt);
    }
}
