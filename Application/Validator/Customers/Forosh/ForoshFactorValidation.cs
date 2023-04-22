using Domain.Models.Customers.Foroosh;

namespace Application.Validator.Customers.Forosh;

public class ForoshFactorValidation : AbstractValidator<ForooshFactor>
{
    public ForoshFactorValidation()
    {
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.DiscountPrice).NotEmpty();
        RuleFor(x => x.PriceTotal).NotEmpty();
    }
}