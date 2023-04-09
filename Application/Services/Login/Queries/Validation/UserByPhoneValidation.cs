namespace Application.Services.Login.Queries.Validation;

public class LoginByPhoneValidation : AbstractValidator<UserByPhoneNumberQuery>
{
    public LoginByPhoneValidation()
    {
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Phone).Must(x => x.Length == 11);
        RuleFor(x => x.Phone).Must(x => x.StartsWith("09"));
        RuleFor(x => x.Phone).Must(x => x.All(char.IsDigit));

    }
}