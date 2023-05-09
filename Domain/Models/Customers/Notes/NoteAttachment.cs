namespace Domain.Models.Customers.Notes;

public class CustomerNoteAttachment : BaseEntity
{
    public CustomerNoteAttachment()
    {
        Id = Ulid.NewUlid();
        NoteAttachmentStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public StatusType NoteAttachmentStatusType { get; set; }

    public required Ulid IdCustomerNote { get; set; }
    public virtual CustomerNote? IdCustomerNoteNavigation { get; set; }
}