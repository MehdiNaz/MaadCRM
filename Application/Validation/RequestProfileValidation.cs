namespace Application.Validation;

public class RequestProfileValidation : AbstractValidator<RequestProfile>
{
    public RequestProfileValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("لطفاً نام خود را وارد نمائید");
        RuleFor(x => x.Family).NotEmpty().WithMessage("لطفاً نام خانوادگی خود را وارد نمائید");
        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفاً آدرس ایمیل را وارد نمائید");
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفاً رمز عبور خود را وارد نمائید"); ;
        RuleFor(x => x.DateBirthday).NotEmpty().WithMessage("لطفاً تاریخ تولد خود را وارد نمائید"); ;
    }
}