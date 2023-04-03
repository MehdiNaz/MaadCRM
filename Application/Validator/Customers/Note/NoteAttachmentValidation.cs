namespace Application.Validator.Customers.Note;

public class NoteAttachmentValidation : AbstractValidator<NoteAttachment>
{
    public NoteAttachmentValidation()
    {
        RuleFor(x => x.CustomerNoteId).NotEmpty();
        RuleFor(x => x.FileName).NotEmpty();
        RuleFor(x => x.Extenstion).NotEmpty().WithMessage("لطفاً پسوند را وارد نمائید");
    }
}
