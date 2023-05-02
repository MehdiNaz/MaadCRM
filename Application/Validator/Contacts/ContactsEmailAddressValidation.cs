namespace Application.Validator.Contacts;

public class ContactsEmailAddressValidation : AbstractValidator<ContactsEmailAddress>
{
    public ContactsEmailAddressValidation()
    {
        RuleFor(x => x.ContactEmailAddress).NotEmpty().WithMessage("لطفاً آدرس ایمیل را درج نمائید");
    }
}