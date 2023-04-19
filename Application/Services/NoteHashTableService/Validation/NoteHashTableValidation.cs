namespace Application.Services.NoteHashTableService.Validation;

public class NoteHashTableValidation : AbstractValidator<NoteHashTable>
{
    public NoteHashTableValidation()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً عنوان را وارد نمائید");
    }
}