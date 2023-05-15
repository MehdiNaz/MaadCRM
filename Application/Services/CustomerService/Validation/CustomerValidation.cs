namespace Application.Services.CustomerService.Validation;

public class CustomerValidation : AbstractValidator<CustomerFilterRequest>
{
    public CustomerValidation()
    {
        RuleFor(x => x.BirthDayDate).NotEmpty().WithMessage("لطفاً تاریخ تولد را وارد نمائید");
        RuleFor(x => x.Gender).NotEmpty();
    }
}
//public Ulid? CustomerId { get; set; }
//public DateOnly?  { get; set; }
//public GenderTypes?  { get; set; }
//public Ulid? CityId { get; set; }
//public Ulid? ProvinceId { get; set; }
//public CustomerStateTypes? CustomerState { get; set; }
//public DateTime?  { get; set; }
//public DateTime? UpTo { get; set; }
//public Ulid? MoshtaryMoAref { get; set; }
//public Ulid? ProductCustomerFavorite { get; set; }
//public Ulid ProductId { get; set; }
//public string ProductName { get; set; }
//public string UserId { get; set; }