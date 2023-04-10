namespace Application.Services.SanAtService.Validation;

public class SanAtValidation: AbstractValidator<SanAt>
{
    public SanAtValidation()
    {
        RuleFor(x => x.SanAtName).NotEmpty().WithMessage("لطفا نام صنعت را وارد نمائید");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("لطفا کاربر را انتخاب نمائید");
    }
}