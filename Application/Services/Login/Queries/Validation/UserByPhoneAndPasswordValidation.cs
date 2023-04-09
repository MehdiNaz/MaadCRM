namespace Application.Services.Login.Queries.Validation;

public class UserByPhoneAndPasswordValidation : AbstractValidator<UserByPhoneAndPasswordQuery>
{
    public UserByPhoneAndPasswordValidation()
    {
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Phone).Must(x => x.Length == 11);
        RuleFor(x => x.Phone).Must(x => x.StartsWith("09"));
        RuleFor(x => x.Phone).Must(x => x.All(char.IsDigit));

        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password).Must(x => x.Length >= 8);
        
    }
}