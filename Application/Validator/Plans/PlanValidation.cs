namespace Application.Validator.Plans;

public class PlanValidation : AbstractValidator<Plan>
{
    public PlanValidation()
    {
        RuleFor(x => x.PlanName).NotEmpty().WithMessage("لطفاً نام پلن را وارد نمائید");
        RuleFor(x => x.DayDurations).NotEmpty().WithMessage("لطفاً تعداد روز را وارد نمائید");
        RuleFor(x => x.CountOfUsers).NotEmpty().WithMessage("لطفاً تعداد کاربران را وارد نمائید");
    }
}