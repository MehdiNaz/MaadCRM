namespace Application.Validator.Contacts;

public class ContactGroupValidation : AbstractValidator<ContactGroup>
{
    public ContactGroupValidation()
    {
        RuleFor(x => x.GroupName).NotEmpty().WithMessage("لطفاً نام دسته بندی را وارد نمائید");
        RuleFor(x => x.DisplayOrder).NotEmpty();
    }
}