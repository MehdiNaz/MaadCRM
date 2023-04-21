namespace Application.Validator.Customers.Forosh;

public class ForoshOrderValidation : AbstractValidator<ForooshOrder>
{
    public ForoshOrderValidation()
    {
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.ShippingPrice).NotEmpty();
        RuleFor(x => x.PriceTotal).NotEmpty();
        RuleFor(x => x.DiscountPrice).NotEmpty();
    }
}