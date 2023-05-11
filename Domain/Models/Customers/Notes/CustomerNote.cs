namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntityWithUserUpdate
{
    public CustomerNote()
    {
        Id = Ulid.NewUlid();
        CustomerNoteStatusType = StatusType.Show;
        NoteHashTags = new HashSet<CustomerNoteHashTag>();
        NoteAttachments = new HashSet<CustomerNoteAttachment>();
        Logs = new HashSet<Log>();
    }

    public Ulid Id { get; set; }
    public string Description { get; set; }
    public StatusType CustomerNoteStatusType { get; set; }

    public Ulid? IdProduct { get; set; }
    public virtual Product? IdProductNavigation { get; set; }

    public required Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    

    public virtual ICollection<CustomerNoteHashTag>? NoteHashTags { get; set; }
    public virtual ICollection<CustomerNoteAttachment>? NoteAttachments { get; set; }
    public virtual ICollection<Log>? Logs { get; set; }
}