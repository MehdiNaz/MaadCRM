namespace Application.Services.NoteAttachmentService.Commands;

public struct ChangeStatusNoteAttachmentCommand : IRequest<NoteAttachment?>
{
    public Ulid Id { get; set; }
    public Status NoteAttachmentStatus { get; set; }
}