namespace Application.Services.NoteAttachmentService.Queries;

public struct NoteAttachmentByIdQuery : IRequest<CustomerNoteAttachment>
{
    public Ulid NoteAttachmentId { get; set; }
}