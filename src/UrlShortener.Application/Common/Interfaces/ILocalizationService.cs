namespace UrlShortener.Application.Common.Interfaces;

public interface ILocalizationService
{
    string GetString(string key, params object[] args);
}