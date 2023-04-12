namespace Application.Services.NoteAttachmentService.Commands;

public struct ChangeStatusNoteAttachmentCommand : IRequest<NoteAttachment?>
{
    public Ulid NoteAttachmentId { get; set; }
    public Status NoteAttachmentStatus { get; set; }
}