using System.Security.Cryptography;
using UrlShortener.Domain.Interfaces;

namespace UrlShortener.Infrastructure.Services;

public class ShortCodeGenerator : IShortCodeGenerator
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string Generate(int length = 6)
    {
        if (length <= 0)
            throw new ArgumentException(nameof(length), "Length must be greater than zero.");

        Span<char> buffer = stackalloc char[length];
        Span<byte> randomBytes = stackalloc byte[length];

        RandomNumberGenerator.Fill(randomBytes);

        for(int i = 0; i < length; i++)
        {
            // Map each random byte to an index within the alphabet
            int index = randomBytes[i] % Alphabet.Length;
            buffer[i] = Alphabet[index];
        }

        return new string(buffer);
    }

    public string GenerateUnique(int length, Func<string, bool> existsCheck, int maxAttempts = 5)
    {
        if (existsCheck is null)
            throw new ArgumentNullException(nameof(existsCheck));

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            var code = Generate(length);
            if (!existsCheck(code))
                return code;
        }

        throw new InvalidOperationException(
            $"Could not generate a unique short code after {maxAttempts} attempts.");
    }
}
