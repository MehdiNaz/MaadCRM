namespace Application.Validator.Customers;

public class SanAtValidator : AbstractValidator<SanAt>
{
    public SanAtValidator()
    {
        RuleFor(x => x.SanAtName).NotEmpty().WithMessage("لطفا نام صنعت را وارد نمائید");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("لطفا کاربر را انتخاب نمائید");
    }
}