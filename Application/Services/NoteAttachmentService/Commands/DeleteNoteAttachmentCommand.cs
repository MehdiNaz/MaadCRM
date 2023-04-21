namespace Application.Services.NoteAttachmentService.Commands;

public struct DeleteNoteAttachmentCommand : IRequest<CustomerNoteAttachment>
{
    public Ulid Id { get; set; }
}