namespace Application.Validator.SpecialFields;

public class AttributeOptionsValidation : AbstractValidator<AttributeOptions>
{
    public AttributeOptionsValidation()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً نام را وارد نمائید");
        RuleFor(x => x.ColorSquaresRgb).NotEmpty().WithMessage("لطفاً رنگ را وارد نمائید");
    }
}
