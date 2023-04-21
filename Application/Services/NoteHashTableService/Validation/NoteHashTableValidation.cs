namespace Application.Services.NoteHashTableService.Validation;

public class NoteHashTableValidation : AbstractValidator<CustomerNoteHashTable>
{
    public NoteHashTableValidation()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً عنوان را وارد نمائید");
    }
}