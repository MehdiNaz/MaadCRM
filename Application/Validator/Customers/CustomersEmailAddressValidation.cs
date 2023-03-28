namespace Application.Validator.Customers;

public class CustomersEmailAddressValidation : AbstractValidator<CustomersEmailAddress>
{
    public CustomersEmailAddressValidation()
    {
        RuleFor(x => x.CustomersEmailAddrs).NotEmpty().WithMessage("لطفاً آدرس ایمیل را وارد نمائید");
    }
}