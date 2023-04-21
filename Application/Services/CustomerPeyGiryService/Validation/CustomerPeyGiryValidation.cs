namespace Application.Services.CustomerPeyGiryService.Validation;

public class CustomerPeyGiryValidation : AbstractValidator<CustomerPeyGiry>
{
    public CustomerPeyGiryValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("لطفاً توضیحات را وارد نمائید");
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}
