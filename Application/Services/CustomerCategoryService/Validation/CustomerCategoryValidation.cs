namespace Application.Services.CustomerCategoryService.Validation;

public class CustomerCategoryValidation : AbstractValidator<CustomerFeedbackCategory>
{
    public CustomerCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("لطفاً نام دسته بندی را وارد نمائید");
    }
}