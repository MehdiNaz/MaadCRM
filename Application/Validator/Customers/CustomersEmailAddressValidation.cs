namespace Application.Validator.Customers;

public class CustomersEmailAddressValidation : AbstractValidator<CustomersEmailAddress>
{
    public CustomersEmailAddressValidation()
    {
        RuleFor(x => x.CustomersEmailAddrs).EmailAddress().WithMessage("لطفاً آدرس ایمیل  را وارد نمائید"); ;
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}