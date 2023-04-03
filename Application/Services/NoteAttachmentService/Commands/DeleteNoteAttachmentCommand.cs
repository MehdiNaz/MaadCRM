namespace Application.Services.NoteAttachmentService.Commands;

public struct DeleteNoteAttachmentCommand : IRequest<NoteAttachment>
{
    public Ulid NoteAttachmentId { get; set; }
}