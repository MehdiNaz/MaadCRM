namespace Domain.Models.Customers.PeyGiry;

public class PeyGiryAttachment : BaseEntity
{
    public PeyGiryAttachment()
    {
        PeyGiryAttachmentId = Ulid.NewUlid();
        StatusPeyGiryAttachment = Status.Show;
    }

    public Ulid PeyGiryAttachmentId { get; set; }
    public Ulid PeyGiryNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status StatusPeyGiryAttachment { get; set; }

    public CustomerPeyGiry CustomerPeyGiry { get; set; }
}