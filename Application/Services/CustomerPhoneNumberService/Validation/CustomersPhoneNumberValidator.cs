namespace Application.Services.CustomerPhoneNumberService.Validation;

public class CustomersPhoneNumberValidator : AbstractValidator<CustomersPhoneNumber>
{
    public CustomersPhoneNumberValidator()
    {
        RuleFor(x => x.PhoneNo).NotEmpty().WithMessage("لطفاً شماره را وارد نمائید");
        RuleFor(x => x.PhoneType).NotEmpty().WithMessage("لطفاً مقدار ورودی را وارد نمائید");
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("لطفاً مقدار ورودی را وارد نمائید");
    }
}