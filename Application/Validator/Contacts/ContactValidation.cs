namespace Application.Validator.Contacts;

public class ContactValidation : AbstractValidator<Contact>
{
    public ContactValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفاً نام مخاطب را وارد نمائید");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفاً نام خانوادگی مخاطب را وارد نمائید");
        RuleFor(x => x.Job).NotEmpty().WithMessage("لطفاً شغل مخاطب را وارد نمائید");
        RuleFor(x => x.EmailId).NotEmpty();
        RuleFor(x => x.ContactGroupId).NotEmpty();
        RuleFor(x => x.BusinessId).NotEmpty();
    }
}