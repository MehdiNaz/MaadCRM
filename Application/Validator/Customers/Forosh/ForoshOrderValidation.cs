namespace Application.Validator.Customers.Foroosh;

public class ForooshOrderValidation : AbstractValidator<ForooshOrder>
{
    public ForooshOrderValidation()
    {
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.PriceShipping).NotEmpty();
        RuleFor(x => x.PriceTotal).NotEmpty();
        RuleFor(x => x.PriceDiscount).NotEmpty();
    }
}