using FluentValidation;

namespace UrlShortener.Application.Features.Urls.Commands.UpdateShortUrl;

public class UpdateShortUrlCommandValidator : AbstractValidator<UpdateShortUrlCommand>
{
    public UpdateShortUrlCommandValidator()
    {
        RuleFor(x => x.ExpiresAt)
            .GreaterThan(DateTime.UtcNow)
            .When(x => x.ExpiresAt.HasValue)
            .WithMessage("Expiration date must be in the future.");

        RuleFor(x => x)
            .Must(x => x.ExpiresAt.HasValue || x.IsActive.HasValue)
            .WithMessage("At least one field must be provided to update.");
    }
}