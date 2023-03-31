namespace Domain.Models.Customers;

public class NoteAttachment : BaseEntity
{
    public NoteAttachment()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid NoteAttachmentId { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status IsDeleted { get; set; }

    public CustomerNote CustomerNote { get; set; }
}