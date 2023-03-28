namespace Application.Validator.Customers;

public class CustCategoryValidation : AbstractValidator<CustCategory>
{
    public CustCategoryValidation()
    {
        RuleFor(x => x.CustomerCategoryName).NotEmpty().WithMessage("لطفاً نام دسته بندی را وارد نمائید");
        RuleFor(x => x.IsShown).NotEmpty();
    }
}