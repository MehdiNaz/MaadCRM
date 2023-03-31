namespace Domain.Models.Customers.PeyGiry;

public class PeyGiryAttachment : BaseEntity
{
    public PeyGiryAttachment()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid PeyGiryAttachmentId { get; set; }
    public Ulid PeyGiryNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status IsDeleted { get; set; }

    public CustomerPeyGiry CustomerPeyGiry { get; set; }

}