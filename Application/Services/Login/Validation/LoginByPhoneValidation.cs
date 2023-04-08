namespace Application.Services.Login.Validation;

public class LoginByPhoneValidation : AbstractValidator<UserByPhoneNumberQuery>
{
    public LoginByPhoneValidation()
    {
        RuleFor(x => x.Phone).NotEmpty();
    }

}