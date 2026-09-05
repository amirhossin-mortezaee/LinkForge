namespace UrlShortener.Application.Common.Exceptions;

public class ShortUrlNotAvailableException : Exception
{
    public ShortUrlNotAvailableException(string shortCode)
        : base($"Short URL '{shortCode}' is no longer available (inactive or expired).")
    {
    }
}
