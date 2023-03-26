namespace Application.Validator.SpecialFields;

public class BusinessAttributeValidation : AbstractValidator<BusinessAttribute>
{
    public BusinessAttributeValidation()
    {
        RuleFor(x => x.TextPrompt).NotEmpty().WithMessage("لطفاً متن درخواست را وارد نمائید");
        RuleFor(x => x.IsRequired).NotEmpty();
        RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage("لطفاً شماره سفارش را وارد نمائید");
        RuleFor(x => x.ValidationMinLength).NotEmpty().WithMessage("لطفاً حداقل میزان ورودی را وارد نمائید");
        RuleFor(x => x.ValidationMaxLength).NotEmpty().WithMessage("لطفاً حداکثر میزان ورودی را وارد نمائید");
        RuleFor(x => x.ValidationFileAllowExtention).NotEmpty().WithMessage("لطفاً فایل اعتبار سنجی را وارد نمائید");
        RuleFor(x => x.ValidationFileMaximumSize).NotEmpty().WithMessage("لطفاً حداکثر اعتبار سنجی را وارد نمائید");
        RuleFor(x => x.DefaultValue).NotEmpty().WithMessage("لطفاً میزان پیش فرض را وارد نمائید");
        RuleFor(x => x.ConditionValue).NotEmpty().WithMessage("لطفاً مقدار شرطی را وارد نمائید");
    }
}