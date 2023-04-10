namespace Application.Services.CustomerActivityService.Validation;

public class CustomerActivityValidation : AbstractValidator<CustomerActivity>
{
    public CustomerActivityValidation()
    {
        RuleFor(x => x.CustomerActivityName).NotEmpty().WithMessage("لطفاً نام فعالیت مشتری را وارد نمائید");
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}