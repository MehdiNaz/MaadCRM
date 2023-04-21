namespace Application.Services.NoteAttachmentService.Commands;

public struct ChangeStatusNoteAttachmentCommand : IRequest<CustomerNoteAttachment?>
{
    public Ulid Id { get; set; }
    public Status NoteAttachmentStatus { get; set; }
}