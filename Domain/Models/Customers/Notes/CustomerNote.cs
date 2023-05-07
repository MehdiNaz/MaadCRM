namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntityWithUserUpdate
{
    public CustomerNote()
    {
        Id = Ulid.NewUlid();
        CustomerNoteStatus = Status.Show;
        NoteHashTags = new HashSet<CustomerNoteHashTag>();
        NoteAttachments = new HashSet<CustomerNoteAttachment>();
    }

    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Status CustomerNoteStatus { get; set; }

    public Ulid? IdProduct { get; set; }
    public virtual Product? IdProductNavigation { get; set; }

    public required Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    

    public virtual ICollection<CustomerNoteHashTag>? NoteHashTags { get; set; }
    public virtual ICollection<CustomerNoteAttachment>? NoteAttachments { get; set; }
}