namespace Application.Services.NoteAttachmentService.Queries;

public struct GetNoteAttachmentByIdQuery : IRequest<NoteAttachment>
{
    public Ulid NoteAttachmentId { get; set; }
}