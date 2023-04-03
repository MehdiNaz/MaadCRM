namespace Application.Services.NoteAttachmentService.Commands;

public struct CreateNoteAttachmentCommand : IRequest<NoteAttachment>
{
    public Ulid CustomerNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
}