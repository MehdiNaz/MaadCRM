namespace Application.Validation;

public class RequestLoginByMailValidation : AbstractValidator<UserByEmailAddressQuery>
{
    public RequestLoginByMailValidation()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x=>x.Email).NotEmpty().WithMessage("لطفاً آدرس ایمیل را وارد نمائید");

        RuleFor(x => x.Password).EmailAddress();
        RuleFor(x=>x.Password).NotEmpty().WithMessage("لطفاً رمز عبور را وارد نمائید");
        RuleFor(x => x.Password).MaximumLength(20);
        RuleFor(x => x.Password).MinimumLength(8);
    }
}