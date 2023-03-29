namespace Application.Validator.Contacts;

public class ContactPhoneNumberValidation : AbstractValidator<ContactPhoneNumber>
{
    public ContactPhoneNumberValidation()
    {
        RuleFor(x => x.PhoneNo).NotEmpty().WithMessage("لطفاً شماره تلفن را وارد نمائید");
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}