namespace UrlShortener.Application.Common.Exceptions;

public class RegistrationFailedException : Exception
{
    public RegistrationFailedException(string message)
        : base(message)
    {
    }
}