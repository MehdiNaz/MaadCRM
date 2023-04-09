namespace Application.Services.CustomerCategoryService.Validation;

public class CustomerCategoryValidation : AbstractValidator<CustomerCategory>
{
    public CustomerCategoryValidation()
    {
        RuleFor(x => x.CustomerCategoryName).NotEmpty().WithMessage("لطفاً نام دسته بندی را وارد نمائید");
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}