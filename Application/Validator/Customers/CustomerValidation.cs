namespace Application.Validator.Customers;

public class CustomerValidation : AbstractValidator<Customer>
{
    public CustomerValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفاً نام مشتری را وارد نمائید");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفاً نام خانوادگی مشتری را وارد نمائید");
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد مشتری را وارد نمائید");
        RuleFor(x => x.CustomerPic).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.BusinessId).NotEmpty();
        RuleFor(x => x.CustomerCategoryId).NotEmpty();
        RuleFor(x => x.CustomerState).NotEmpty();
        RuleFor(x => x.CustomerStatus).NotEmpty();
        RuleFor(x => x.InsertedBy).NotEmpty();
        RuleFor(x => x.UpdatedBy).NotEmpty();
        RuleFor(x => x.CustomerMoarefId).NotEmpty();
        RuleFor(x => x.Gender).NotEmpty();
    }
}
