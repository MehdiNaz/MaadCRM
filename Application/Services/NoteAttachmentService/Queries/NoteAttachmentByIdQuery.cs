namespace Application.Services.NoteAttachmentService.Queries;

public struct NoteAttachmentByIdQuery : IRequest<NoteAttachment>
{
    public Ulid NoteAttachmentId { get; set; }
}