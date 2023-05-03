namespace Application.Services.CustomerService.Validation;

public class CustomerValidation : AbstractValidator<Domain.Models.Customers.Customer>
{
    public CustomerValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفاً نام مشتری را وارد نمائید");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفاً نام خانوادگی مشتری را وارد نمائید");
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد مشتری را وارد نمائید");
    }
}
