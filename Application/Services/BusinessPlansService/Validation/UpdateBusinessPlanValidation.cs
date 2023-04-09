namespace Application.Services.BusinessPlansService.Validation;

public class UpdateBusinessPlanValidation : AbstractValidator<UpdateBusinessPlansCommand>
{
    public UpdateBusinessPlanValidation()
    {
        RuleFor(x => x.BusinessPlansId).NotEmpty();
        RuleFor(x => x.PlanId).NotEmpty();
        RuleFor(x => x.BusinessId).NotEmpty().WithMessage("لطفاً ردیف را وارد نمائید");
        RuleFor(x => x.CountOfDay).NotEmpty().WithMessage("لطفاً تعداد روز را وارد نمائید");
        RuleFor(x => x.CountOfUsers).NotEmpty().WithMessage("لطفاً تعداد کاربران را وارد نمائید");
    }
}
