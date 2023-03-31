namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntity
{
    public CustomerNote()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid CustomerNoteId { get; set; }
    public string Description { get; set; }
    public Status IsDeleted { get; set; }
    public Ulid CustomerId { get; set; }

    public Customer Customer { get; set; }
    public ICollection<CustomerHashTag> CustomerHashTags { get; set; }
    public ICollection<NoteAttachment> NoteAttachments { get; set; }
}