namespace Application.Services.NoteAttachmentService.Validation;

public class NoteAttachmentValidation : AbstractValidator<CustomerNoteAttachment>
{
    public NoteAttachmentValidation()
    {
        RuleFor(x => x.IdCustomerNote).NotEmpty();
        RuleFor(x => x.FileName).NotEmpty();
        RuleFor(x => x.Extenstion).NotEmpty().WithMessage("لطفاً پسوند را وارد نمائید");
    }
}
