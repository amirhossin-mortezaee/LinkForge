using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Domain.Tests
{
    public class ShortCodeGeneratorTests
    {
        private readonly ShortCodeGenerator _sut = new();

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(10)]
        public void Generate_ShouldReturnCodeOfRequestedLength(int length)
        {
            // Act
            var code = _sut.Generate(length);
            // Assert
            Assert.Equal(length, code.Length);
        }

        [Fact]
        public void Generate_ShouldOnlyContainBase62Characters()
        {
            const string allowedChars =
                "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var code = _sut.Generate(20);

            Assert.All(code, c => Assert.Contains(c, allowedChars));
        }

        [Fact]
        public void Generate_CalledTwice_ShouldReturnDifferentResults()
        {
            var first = _sut.Generate();
            var second = _sut.Generate();

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void GenerateUnique_ShouldReturnCodeNotInExistingSet()
        {
            var existingCodes = new HashSet<string> { "abc123" };

            var result = _sut.GenerateUnique(
                length: 6,
                existsCheck: code => existingCodes.Contains(code));

            Assert.DoesNotContain(result, existingCodes);
        }

        [Fact]
        public void GenerateUnique_WhenAlwaysColliding_ShouldThrowAfterMaxAttempts()
        {
            Assert.Throws<InvalidOperationException>(() =>
            _sut.GenerateUnique(
                length: 6,
                existsCheck: _ => true, // همیشه می‌گه "این کد از قبل وجود داره"
                maxAttempts: 3));
        }
    }
}
