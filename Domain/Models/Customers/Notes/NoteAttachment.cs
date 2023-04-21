namespace Domain.Models.Customers.Notes;

public class CustomerNoteAttachment : BaseEntity
{
    public CustomerNoteAttachment()
    {
        Id = Ulid.NewUlid();
        NoteAttachmentStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status NoteAttachmentStatus { get; set; }

    public required Ulid IdCustomerNote { get; set; }
    public virtual CustomerNote? IdCustomerNoteNavigation { get; set; }
    
    
    public byte[] RowVersion { get; set; }
}