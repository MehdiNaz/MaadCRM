namespace Application.Services.NoteAttachmentService.Commands;

public struct DeleteNoteAttachmentCommand : IRequest<NoteAttachment>
{
    public Ulid Id { get; set; }
}