namespace Domain.Models.Customers.Notes;

public class CustomerNoteHashTag : BaseEntity
{
    public CustomerNoteHashTag()
    {
        Id = Ulid.NewUlid();
        StatusNoteHashTag = Status.Show;
    }

    public Ulid Id { get; set; }

    public Status StatusNoteHashTag { get; set; }

    public Ulid IdCustomerNote { get; set; }
    public virtual CustomerNote? IdCustomerNoteNavigation { get; set; }

    public Ulid IdNoteHashTable { get; set; }
    public virtual CustomerNoteHashTable? IdNoteHashTableNavigation { get; set; }


    public uint Version { get; set; }
}