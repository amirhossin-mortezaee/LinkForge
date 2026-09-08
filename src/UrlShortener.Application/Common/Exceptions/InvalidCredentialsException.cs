namespace UrlShortener.Application.Common.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException()
        : base("ایمیل یا رمز عبور نادرست است.")
    {
    }
}