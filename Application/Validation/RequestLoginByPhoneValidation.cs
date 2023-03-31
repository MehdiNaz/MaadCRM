namespace Application.Validation;

public class RequestLoginByPhoneValidation : AbstractValidator<RequestLoginByPhone>
{
    public RequestLoginByPhoneValidation()
    {
        RuleFor(x => x.Phone).Length(11);
        RuleFor(x => x.Phone).NotEmpty().WithMessage("لطفاً شماره خود را وارد نمائید");
    }
}