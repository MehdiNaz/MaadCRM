namespace Application.Validator;

public class RequestLoginByPhoneValidator : AbstractValidator<RequestLoginByPhone>
{
    public RequestLoginByPhoneValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().WithMessage("لطفاً نام کاربری را وارد نمائید");

        RuleFor(x => x.Phone).Length(11).WithMessage("لطفاً نام کاربری را به صورت یازده کاراکتری وارد نمائید");
    }
}
