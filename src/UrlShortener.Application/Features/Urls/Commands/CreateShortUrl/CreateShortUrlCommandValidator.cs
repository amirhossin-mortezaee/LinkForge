using FluentValidation;
using UrlShortener.Domain.Common;

namespace UrlShortener.Application.Features.Urls.Commands.CreateShortUrl;

public class CreateShortUrlCommandValidator : AbstractValidator<CreateShortUrlCommand>
{
    public CreateShortUrlCommandValidator()
    {
        RuleFor(x => x.OriginalUrl)
            .NotEmpty()
                .WithMessage("Original URL is required.")
            .MaximumLength(ShortUrlConstants.OriginalUrlMaxLength)
                .WithMessage($"Original URL must not exceed {ShortUrlConstants.OriginalUrlMaxLength} characters.")
            .Must(BeAValidUri)
                .WithMessage("Original URL is not a valid URL.")
            .Must(HaveHttpOrHttpsScheme)
                .WithMessage("Only http and https URLs are allowed.")
                .When(x => BeAValidUri(x.OriginalUrl));

        RuleFor(x => x.CustomAlias)
            .MaximumLength(ShortUrlConstants.CustomAliasMaxLength)
                .WithMessage($"Custom alias must not exceed {ShortUrlConstants.CustomAliasMaxLength} characters.")
            .Matches("^[a-zA-Z0-9_-]+$")
                .WithMessage("Custom alias can only contain letters, digits, hyphens, and underscores.")
            .When(x => !string.IsNullOrEmpty(x.CustomAlias));

        RuleFor(x => x.ExpiresAt)
            .GreaterThan(DateTime.UtcNow)
                .WithMessage("Expiration date must be in the future.")
            .When(x => x.ExpiresAt.HasValue);
    }

    private static bool BeAValidUri(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

    private static bool HaveHttpOrHttpsScheme(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uri)
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}