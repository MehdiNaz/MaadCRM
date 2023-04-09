namespace Application.Services.Login.Commands.Validation;

public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidation()
    {
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Phone).Must(x => x.Length == 11);
        RuleFor(x => x.Phone).Must(x => x.StartsWith("09"));
        RuleFor(x => x.Phone).Must(x => x.All(char.IsDigit));
    }
}