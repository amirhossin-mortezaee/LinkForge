namespace UrlShortener.Application.Common.Exceptions;

public class ShortUrlNotAvailableException : Exception
{
    public ShortUrlNotAvailableException(string shortCode)
        : base($"لینک کوتاه '{shortCode}' دیگر در دسترس نیست (غیرفعال یا منقضی شده).")
    {
    }
}
