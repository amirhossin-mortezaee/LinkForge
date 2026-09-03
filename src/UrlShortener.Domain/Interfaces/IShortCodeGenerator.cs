namespace UrlShortener.Domain.Interfaces;


/// <summary>
/// Generates short, unique codes used as the identifier portion of a shortened URL.
/// </summary>
public interface IShortCodeGenerator
{
    /// <summary>
    /// Generates a random short code of the given length.
    /// </summary>
    string Generate(int length = 6);

    /// <summary>
    /// Generates a short code that does not satisfy the given existence check,
    /// retrying up to maxAttempts times.
    /// </summary>
    string GenerateUnique(int length, Func<string, bool> existsCheck, int maxAttempts = 5);
}
