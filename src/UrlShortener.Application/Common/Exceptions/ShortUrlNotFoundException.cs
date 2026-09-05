namespace UrlShortener.Application.Common.Exceptions;

public class ShortUrlNotFoundException : Exception
{
    public ShortUrlNotFoundException(string shortCode)
        : base($"No short URL found for code '{shortCode}'.")
    {
    }
}
