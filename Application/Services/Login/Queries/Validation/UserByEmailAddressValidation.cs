
namespace Application.Services.Login.Queries.Validation;

public class UserByEmailAddressValidation : AbstractValidator<UserByEmailAddressQuery>
{
    public UserByEmailAddressValidation()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();


        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password).Must(x => x.Length >= 8);
    }
}