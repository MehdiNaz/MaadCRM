namespace Application.Validator.SpecialFields;

public class AttributeOptionsValueValidation : AbstractValidator<AttributeOptionValue>
{
    public AttributeOptionsValueValidation()
    {
        RuleFor(x => x.ForCustomerId).NotEmpty();
        RuleFor(x => x.AttributeDescriptionValue).NotEmpty().WithMessage("لطفاً توضیحات را درج نمائید");
        RuleFor(x => x.AttributeXMLValue).NotEmpty().WithMessage("لطفاً مقدار ایکس ام ال را درج نمائید");
        RuleFor(x => x.AttributeJsonValue).NotEmpty().WithMessage("لطفاً مقدار جی سان را درج نمائید");
        RuleFor(x => x.FileId).NotEmpty();
        RuleFor(x => x.PictureId).NotEmpty();
        RuleFor(x => x.FilePath).NotEmpty().WithMessage("لطفاً آدرس فایل را درج نمائید");
        RuleFor(x => x.ImagePath).NotEmpty().WithMessage("لطفاً آدرس عکس را درج نمائید");
    }
}