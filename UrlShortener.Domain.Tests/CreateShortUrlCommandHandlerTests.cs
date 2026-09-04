using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Application.Common.Interfaces;
using UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Domain.Tests.Features.Urls.Commands;

public class CreateShortUrlCommandHandlerTests
{
    private static AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldSaveShortUrlToDatabase()
    {
        // Arrange
        await using var context = CreateInMemoryContext();
        var generator = new FakeShortCodeGenerator("abc123");
        var handler = new CreateShortUrlCommandHandler(context, generator);

        var command = new CreateShortUrlCommand(
            OriginalUrl: "https://www.google.com",
            CustomAlias: null,
            ExpiresAt: null,
            UserId: null);

        // Act
        var resultId = await handler.Handle(command, CancellationToken.None);

        // Assert
        resultId.Should().NotBeEmpty();

        var savedEntity = await context.ShortUrls.FindAsync(resultId);
        savedEntity.Should().NotBeNull();
        savedEntity!.OriginalUrl.Should().Be("https://www.google.com");
        savedEntity.ShortCode.Should().Be("abc123");
        savedEntity.ClickCount.Should().Be(0);
        savedEntity.IsActive.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_WithDuplicateCustomAlias_ShouldThrowDuplicateShortCodeException()
    {
        // Arrange
        await using var context = CreateInMemoryContext();
        var generator = new FakeShortCodeGenerator("shouldNotBeUsed");
        var handler = new CreateShortUrlCommandHandler(context, generator);

        context.ShortUrls.Add(ShortUrl.Create(
            "https://existing.com", "my-alias", null, null));
        await context.SaveChangesAsync();

        var command = new CreateShortUrlCommand(
            OriginalUrl: "https://new-url.com",
            CustomAlias: "my-alias",
            ExpiresAt: null,
            UserId: null);

        // Act
        var act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DuplicateShortCodeException>();
    }

    [Fact]
    public async Task Handle_WithCustomAlias_ShouldUseProvidedAliasAsShortCode()
    {
        // Arrange
        await using var context = CreateInMemoryContext();
        var generator = new FakeShortCodeGenerator("shouldNotBeUsed");
        var handler = new CreateShortUrlCommandHandler(context, generator);

        var command = new CreateShortUrlCommand(
            OriginalUrl: "https://example.com",
            CustomAlias: "custom-path",
            ExpiresAt: null,
            UserId: null);

        // Act
        var resultId = await handler.Handle(command, CancellationToken.None);

        // Assert
        var savedEntity = await context.ShortUrls.FindAsync(resultId);
        savedEntity!.ShortCode.Should().Be("custom-path");
    }

    private sealed class FakeShortCodeGenerator : IShortCodeGenerator
    {
        private readonly string _fixedCode;

        public FakeShortCodeGenerator(string fixedCode)
        {
            _fixedCode = fixedCode;
        }

        public string Generate(int length = 6)
        {
            return _fixedCode;
        }

        public string GenerateUnique(int length, Func<string, bool> existsCheck, int maxAttempts = 5)
        {
            return _fixedCode;
        }
    }
}
