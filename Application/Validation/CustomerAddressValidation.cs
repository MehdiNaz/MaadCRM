namespace Application.Validation;

public class CustomerAddressValidation : AbstractValidator<CustomersAddress>
{
    public CustomerAddressValidation()
    {
        RuleFor(x => x.Address).EmailAddress().WithMessage("لطفاً آدرس  را وارد نمائید");
        RuleFor(x => x.CodePost).NotEmpty().WithMessage("لطفاً کد پستی را وارد نمائید");
        RuleFor(x => x.PhoneNo).NotEmpty().WithMessage("لطفاً تلفن را وارد نمائید");
        RuleFor(x => x.Description).NotEmpty().WithMessage("لطفاً توضیحات را وارد نمائید");
    }
}