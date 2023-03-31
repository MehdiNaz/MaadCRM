namespace Application.Validation;

public class RequestRegisterValidation : AbstractValidator<RequestRegister>
{
    public RequestRegisterValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفاً ایمیل خود را وارد نمائید");
        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Password).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفاً رمز عبور را وارد نمائید");
        RuleFor(x => x.Password).MaximumLength(20);
        RuleFor(x => x.Password).MinimumLength(8);

        RuleFor(x => x.Name).NotEmpty().WithMessage("لطفاً نام خود را وارد نمائید");
        RuleFor(x => x.Family).NotEmpty().WithMessage("لطفاً نام خانوادگی خود را وارد نمائید");
    }
}