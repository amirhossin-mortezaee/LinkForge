using FluentValidation;

namespace UrlShortener.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("ایمیل الزامی است.")
            .EmailAddress().WithMessage("یک آدرس ایمیل معتبر الزامی است.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور الزامی است.");
    }
}