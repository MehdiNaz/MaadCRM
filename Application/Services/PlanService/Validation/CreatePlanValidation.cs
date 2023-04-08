namespace Application.Services.PlanService.Validation;

public class CreatePlanValidation : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanValidation()
    {
        RuleFor(x => x.CountOfUsers).NotEmpty().WithMessage("لطفاً تعداد کاربر را وارد نمائید");
        RuleFor(x => x.PriceOfUsers).NotEmpty().WithMessage("لطفاً هزینه کاربر را وارد نمائید");
        RuleFor(x => x.CountOfDay).NotEmpty().WithMessage("لطفاً قیمت روز را وارد نمائید");
        RuleFor(x => x.PriceOfDay).NotEmpty().WithMessage("لطفاً تعداد روز را وارد نمائید");
    }
}
