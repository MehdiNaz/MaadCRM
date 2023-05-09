namespace Domain.Models.Customers.Notes;

public class CustomerNoteHashTag : BaseEntity
{
    public CustomerNoteHashTag()
    {
        Id = Ulid.NewUlid();
        StatusTypeNoteHashTag = StatusType.Show;
    }

    public Ulid Id { get; set; }

    public StatusType StatusTypeNoteHashTag { get; set; }

    public Ulid IdCustomerNote { get; set; }
    public virtual CustomerNote? IdCustomerNoteNavigation { get; set; }

    public Ulid IdNoteHashTable { get; set; }
    public virtual CustomerNoteHashTable? IdNoteHashTableNavigation { get; set; }
}