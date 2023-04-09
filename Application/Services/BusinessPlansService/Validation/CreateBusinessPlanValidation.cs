namespace Application.Services.BusinessPlansService.Validation;

public class CreateBusinessPlanValidation : AbstractValidator<CreateBusinessPlansCommand>
{
    public CreateBusinessPlanValidation()
    {
        RuleFor(x => x.PlanId).NotEmpty();
        RuleFor(x => x.BusinessId).NotEmpty();
        RuleFor(x => x.CountOfDay).NotEmpty().WithMessage("لطفاً تعداد روز را وارد نمائید");
        RuleFor(x => x.CountOfUsers).NotEmpty().WithMessage("لطفاً تعداد کاربران را وارد نمائید");
    }
}
