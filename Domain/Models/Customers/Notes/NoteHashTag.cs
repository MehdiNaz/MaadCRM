namespace Domain.Models.Customers.Notes;

public class CustomerNoteHashTag : BaseEntity
{
    public CustomerNoteHashTag()
    {
        StatusNoteHashTag = Status.Show;
    }

    public Status StatusNoteHashTag { get; set; }
    
    public required Ulid IdCustomerNote { get; set; }
    public virtual CustomerNote? IdCustomerNoteNavigation { get; set; }
    
    public required Ulid IdNoteHashTable { get; set; }
    public virtual CustomerNoteHashTable? IdNoteHashTableNavigation { get; set; }
    
    
    public byte[] RowVersion { get; set; }
}