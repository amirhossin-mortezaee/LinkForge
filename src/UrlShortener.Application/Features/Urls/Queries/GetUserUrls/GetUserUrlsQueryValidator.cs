using FluentValidation;
using UrlShortener.Domain.Common;

namespace UrlShortener.Application.Features.Urls.Queries.GetUserUrls;

public class GetUserUrlsQueryValidator : AbstractValidator<GetUserUrlsQuery>
{
    public GetUserUrlsQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be at least 1.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, ShortUrlConstants.MaxPageSize)
            .WithMessage($"PageSize must be between 1 and {ShortUrlConstants.MaxPageSize}.");
    }
}