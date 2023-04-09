namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntityWithUpdateInfo
{
    public CustomerNote()
    {
        CustomerNoteId = Ulid.NewUlid();
        CustomerNoteStatus = Status.Show;
    }

    public Ulid CustomerNoteId { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerNoteStatus { get; set; }

    public Customer Customer { get; set; }
    public ICollection<NoteHashTag>? CustomerHashTags { get; set; }
    public ICollection<NoteAttachment>? NoteAttachments { get; set; }
}