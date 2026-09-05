using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Common.Exceptions;

namespace UrlShortener.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, title, detail) = MapException(exception);

        if (statusCode == StatusCodes.Status500InternalServerError)
            _logger.LogError(exception, "Unhandled exception occurred");
        else
            _logger.LogWarning(exception, "Handled exception: {Title}", title);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = _environment.IsDevelopment() ? exception.ToString() : detail,
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    private static (int StatusCode, string Title, string Detail) MapException(Exception exception) => exception switch
    {
        FluentValidation.ValidationException vex =>
            (StatusCodes.Status400BadRequest, "Validation Error", vex.Message),

        DuplicateShortCodeException dex =>
            (StatusCodes.Status409Conflict, "Duplicate Short Code", dex.Message),

        ShortUrlNotFoundException nfex =>
            (StatusCodes.Status404NotFound, "Not Found", nfex.Message),

        ShortUrlNotAvailableException nex =>
            (StatusCodes.Status410Gone, "Link No Longer Available", nex.Message),

        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred",
              "An unexpected error occurred. Please try again later.")
    };
}