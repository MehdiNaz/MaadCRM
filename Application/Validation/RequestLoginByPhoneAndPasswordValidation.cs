namespace Application.Validation;

public class RequestLoginByPhoneAndPasswordValidation : AbstractValidator<UserByPhoneAndPasswordQuery>
{
    public RequestLoginByPhoneAndPasswordValidation()
    {
        RuleFor(x => x.Phone).Length(11);
        RuleFor(x => x.Phone).NotEmpty().WithMessage("لطفاً شماره خود را وارد نمائید");


        RuleFor(x => x.Password).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفاً رمز عبور را وارد نمائید");
        RuleFor(x => x.Password).MaximumLength(20);
        RuleFor(x => x.Password).MinimumLength(8);
    }
}