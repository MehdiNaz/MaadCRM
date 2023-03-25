namespace Application.Validator;

public class CustomerValidation : AbstractValidator<Customer>
{
    public CustomerValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفاً نام مشتری را وارد نمائید");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفاً نام خانوادگی مشتری را وارد نمائید");
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد مشتری را وارد نمائید");
        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفاً آدرس ایمیل مشتری را وارد نمائید");
    }
}