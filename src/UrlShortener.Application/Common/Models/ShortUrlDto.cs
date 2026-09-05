namespace UrlShortener.Application.Common.Models;

public class ShortUrlDto
{
    public Guid Id { get; init; }
    public string OriginalUrl { get; init; } = string.Empty;
    public string ShortCode { get; init; } = string.Empty;
    public int ClickCount { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public bool IsActive { get; init; }
}