namespace Application.Services.PeyGiryAttachmentService.Validation;

public class PeyGiryAttachmentValidation : AbstractValidator<PeyGiryAttachment>
{
    public PeyGiryAttachmentValidation()
    {
        RuleFor(x => x.PeyGiryNoteId).NotEmpty();
        RuleFor(x => x.FileName).NotEmpty();
        RuleFor(x => x.Extenstion).NotEmpty();
    }
}
