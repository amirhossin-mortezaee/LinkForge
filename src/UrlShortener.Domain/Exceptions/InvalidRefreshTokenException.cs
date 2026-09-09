namespace UrlShortener.Domain.Exceptions;

public class InvalidRefreshTokenException : Exception
{
    public InvalidRefreshTokenException()
        : base("Refresh Token نامعتبر یا منقضی‌شده است.")
    {
    }
}
