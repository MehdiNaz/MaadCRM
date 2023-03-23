namespace Application.Validator;

internal class RequestLoginByPhoneAndPasswordValidator : AbstractValidator<RequestLoginByPhoneAndPassword>
{
    public RequestLoginByPhoneAndPasswordValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().WithMessage("لطفاً نام کاربری را وارد نمائید");
        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفاً رمز عبور را وارد نمائید");

        RuleFor(x => x.Phone).Length(11).WithMessage("لطفاً نام کاربری را به صورت یازده کاراکتری وارد نمائید");
        RuleFor(x => x.Password).Length(20).WithMessage("لطفاً رمز عبور را به صورت دقیق وارد نمائید");
    }
}
