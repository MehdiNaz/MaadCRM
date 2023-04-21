namespace Application.Services.CustomersEmailAddressService.Validation;

public class CustomersEmailAddressValidation : AbstractValidator<CustomersEmailAddress>
{
    public CustomersEmailAddressValidation()
    {
        RuleFor(x => x.CustomerEmailAddress).EmailAddress().WithMessage("لطفاً آدرس ایمیل  را وارد نمائید"); ;
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}