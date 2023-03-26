namespace Application.Validator.Customers;

public class CustomerValidation : AbstractValidator<Customer>
{
    public CustomerValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفاً نام مشتری را وارد نمائید");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفاً نام خانوادگی مشتری را وارد نمائید");
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد مشتری را وارد نمائید");
        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفاً آدرس ایمیل مشتری را وارد نمائید");
        RuleFor(x => x.PhoneNumberId).NotEmpty();
        RuleFor(x => x.AddressId).NotEmpty();
        RuleFor(x => x.CityId).NotEmpty();
        RuleFor(x => x.NoteId).NotEmpty();
        RuleFor(x => x.ProvinceId).NotEmpty();
        RuleFor(x => x.CountryId).NotEmpty();
        RuleFor(x => x.WishProductId).NotEmpty();
        RuleFor(x => x.ProfileImageId).NotEmpty();
        RuleFor(x => x.BusinessId).NotEmpty();
        RuleFor(x => x.CustomerRepresentativeHistoryId).NotEmpty();
        RuleFor(x => x.MoarefId).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.CustomerState).NotEmpty();
        RuleFor(x => x.IsDeleted).NotEmpty();
        RuleFor(x => x.Gender).NotEmpty();
    }
}