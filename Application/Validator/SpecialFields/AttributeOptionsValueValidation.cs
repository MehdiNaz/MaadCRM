namespace Application.Validator.SpecialFields;

public class AttributeOptionsValueValidation : AbstractValidator<AttributeOptionValue>
{
    public AttributeOptionsValueValidation()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Value).NotEmpty().WithMessage("لطفاً مقادیر را درج نمائید");
        RuleFor(x => x.FilePath).NotEmpty().WithMessage("لطفاً آدرس فایل را درج نمائید");
    }
}