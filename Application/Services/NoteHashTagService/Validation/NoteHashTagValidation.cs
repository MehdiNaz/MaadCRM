namespace Application.Services.NoteHashTagService.Validation;

public class NoteHashTagValidation : AbstractValidator<NoteHashTag>
{
    public NoteHashTagValidation()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً عنوان را وارد نمائید");
        RuleFor(x => x.CustomerNoteId).NotEmpty();
    }
}
