namespace Application.Validator.Customers.Note;

public class CustomerNoteValidation : AbstractValidator<CustomerNote>
{
    public CustomerNoteValidation()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("لطفاً یادداشت  را وارد نمائید");
    }
}