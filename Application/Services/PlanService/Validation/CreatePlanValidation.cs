namespace Application.Services.PlanService.Validation;

public class CreateUsersPlanValidation : AbstractValidator<CreatePlanCommand>
{
    public CreateUsersPlanValidation()
    {
        RuleFor(x => x.PlanName).NotEmpty().WithMessage("لطفاً نام پلن را وارد نمائید");
        RuleFor(x => x.CountOfUsers).NotEmpty().WithMessage("لطفاً تعداد کاربر را وارد نمائید");
        RuleFor(x => x.PriceOfUsers).NotEmpty().WithMessage("لطفاً هزینه کاربر را وارد نمائید");
        RuleFor(x => x.CountOfDay).NotEmpty().WithMessage("لطفاً قیمت روز را وارد نمائید");
        RuleFor(x => x.PriceOfDay).NotEmpty().WithMessage("لطفاً تعداد روز را وارد نمائید");
    }
}
