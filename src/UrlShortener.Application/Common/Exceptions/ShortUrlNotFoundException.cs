namespace UrlShortener.Application.Common.Exceptions;

public class ShortUrlNotFoundException : Exception
{
    public ShortUrlNotFoundException(Guid id)
        : base($"No short URL found for id '{id}'.")
    {
    }

    public ShortUrlNotFoundException(string shortCode)
        : base($"No short URL found for code '{shortCode}'.")
    {
    }
}
