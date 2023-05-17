namespace Application.Services.Customer.CustomerService.Validation;

public class CustomerValidation : AbstractValidator<CustomerFilterRequest>
{
    public CustomerValidation()
    {
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد را وارد نمائید");
        RuleFor(x => x.Gender).NotEmpty();
    }
}
//public Ulid? IdCustomer { get; set; }
//public DateOnly?  { get; set; }
//public GenderTypes?  { get; set; }
//public Ulid? IdCity { get; set; }
//public Ulid? IdProvince { get; set; }
//public CustomerStateTypes? CustomerState { get; set; }
//public DateTime?  { get; set; }
//public DateTime? UpTo { get; set; }
//public Ulid? MoshtaryMoAref { get; set; }
//public Ulid? ProductCustomerFavorite { get; set; }
//public Ulid IdProduct { get; set; }
//public string ProductName { get; set; }
//public string IdUser { get; set; }