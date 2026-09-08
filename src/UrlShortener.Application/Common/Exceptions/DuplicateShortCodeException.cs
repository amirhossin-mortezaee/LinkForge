namespace UrlShortener.Application.Common.Exceptions;

public class DuplicateShortCodeException : Exception
{
    public DuplicateShortCodeException(string shortCode)
        : base($"کد کوتاه '{shortCode}' قبلاً استفاده شده است. لطفاً یک نام مستعار دیگر انتخاب کنید.")
    {
    }
}
