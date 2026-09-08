using FluentValidation;

namespace UrlShortener.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("ایمیل الزامی است.")
            .EmailAddress().WithMessage("یک آدرس ایمیل معتبر الزامی است.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور الزامی است.")
            .MinimumLength(8).WithMessage("رمز عبور باید حداقل 8 کاراکتر باشد.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("تایید رمز عبور الزامی است.")
            .Equal(x => x.Password).WithMessage("رمز عبور و تایید آن یکسان نیستند.");
    }
}