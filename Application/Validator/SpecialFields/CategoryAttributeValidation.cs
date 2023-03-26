namespace Application.Validator.SpecialFields;

public class CategoryAttributeValidation : AbstractValidator<CategoryAttribute>
{
    public CategoryAttributeValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("لطفاً نام را وارد نمائید");
        RuleFor(x => x.Description).NotEmpty().WithMessage("لطفاً توضیحات را وارد نمائید");
        RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage("لطفاً شماره سفارش را وارد نمائید");
    }
}