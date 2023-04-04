namespace Application.Validator.Customers.Forosh;

public class ForoshFactorValidation : AbstractValidator<ForoshFactor>
{
    public ForoshFactorValidation()
    {
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.DiscountPrice).NotEmpty();
        RuleFor(x => x.FinalTotal).NotEmpty();
    }
}