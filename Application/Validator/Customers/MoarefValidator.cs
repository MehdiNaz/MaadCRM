namespace Application.Validator.Customers;

public class MoarefValidator : AbstractValidator<Moaref>
{
    public MoarefValidator()
    {
        RuleFor(x => x.MoarefName).NotEmpty().WithMessage("لطفاً نام معرف را وارد نمائید");
        RuleFor(x => x.MoarefFamily).NotEmpty().WithMessage("لطفاً نام خانوادگی معرف را وارد نمائید");
        RuleFor(x => x.MoarefPhone).NotEmpty().WithMessage("لطفاً تلفن معرف را وارد نمائید");
    }
}