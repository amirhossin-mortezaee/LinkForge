namespace UrlShortener.Application.Common.Exceptions;

public class DuplicateShortCodeException : Exception
{
    public DuplicateShortCodeException(string shortCode)
        : base($"The short code '{shortCode}' is already taken. Please choose a different alias.")
    {
    }
}
