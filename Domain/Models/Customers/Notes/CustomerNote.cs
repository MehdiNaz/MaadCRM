namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntity
{
    public CustomerNote()
    {
        Id = Ulid.NewUlid();
        CustomerNoteStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerNoteStatus { get; set; }
    public Ulid? ProductId { get; set; }

    // public Customer Customer { get; set; }
    public ICollection<NoteHashTag>? NoteHashTags { get; set; }
    public ICollection<NoteAttachment>? NoteAttachments { get; set; }
}