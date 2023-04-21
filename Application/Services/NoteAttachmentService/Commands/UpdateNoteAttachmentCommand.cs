namespace Application.Services.NoteAttachmentService.Commands;

public struct UpdateNoteAttachmentCommand : IRequest<CustomerNoteAttachment>
{
    public Ulid Id { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
}