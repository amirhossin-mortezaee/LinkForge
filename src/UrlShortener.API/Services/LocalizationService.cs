using Microsoft.Extensions.Localization;
using UrlShortener.API.Resources;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.API.Services;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer<Messages> _localizer;

    public LocalizationService(IStringLocalizer<Messages> localizer)
    {
        _localizer = localizer;
    }

    public string GetString(string key, params object[] args)
    {
        var localizedString = _localizer[key];
        return args.Length > 0 ? string.Format(localizedString, args) : localizedString;
    }
}