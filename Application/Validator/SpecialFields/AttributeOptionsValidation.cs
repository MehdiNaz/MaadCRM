namespace Application.Validator.SpecialFields;

public class AttributeOptionsValidation : AbstractValidator<AttributeOptions>
{
    public AttributeOptionsValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("لطفاً نام را وارد نمائید");
        RuleFor(x => x.ColorSquaresRgb).NotEmpty().WithMessage("لطفاً رنگ را وارد نمائید");
        RuleFor(x => x.ImageSequrePictureId).NotEmpty().WithMessage("لطفاً شماره سفارش را وارد نمائید");
    }
}
