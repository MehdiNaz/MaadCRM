namespace Application.Validator.Addresses;

public class CityValidation : AbstractValidator<City>
{
    public CityValidation()
    {
        RuleFor(x => x.CityName).NotEmpty().WithMessage("لطفاً نام شهر را وارد نمائید");
        RuleFor(x => x.IsDefault).NotEmpty();
        RuleFor(x => x.DisplayOrder).NotEmpty();
        RuleFor(x => x.ProvinceId).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}