namespace Application.Services.CustomersEmailAddressService.Validation;

public class CustomersEmailAddressValidation : AbstractValidator<CustomersEmailAddress>
{
    public CustomersEmailAddressValidation()
    {
        RuleFor(x => x.CustomersEmailAddrs).EmailAddress().WithMessage("لطفاً آدرس ایمیل  را وارد نمائید"); ;
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}