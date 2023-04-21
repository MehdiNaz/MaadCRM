namespace Application.Services.NoteHashTagService.Validation;

public class NoteHashTagValidation : AbstractValidator<CustomerNoteHashTag>
{
    public NoteHashTagValidation()
    {
        // RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً عنوان را وارد نمائید");
        RuleFor(x => x.IdCustomerNote).NotEmpty();
    }
}
