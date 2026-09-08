namespace UrlShortener.Application.Common.Exceptions;

public class ShortUrlNotFoundException : Exception
{
    public ShortUrlNotFoundException(Guid id)
        : base($"لینک کوتاه با شناسه '{id}' یافت نشد.")
    {
    }

    public ShortUrlNotFoundException(string shortCode)
        : base($"لینک کوتاه با کد '{shortCode}' یافت نشد.")
    {
    }
}
