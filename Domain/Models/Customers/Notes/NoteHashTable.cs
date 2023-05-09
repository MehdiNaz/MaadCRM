namespace Domain.Models.Customers.Notes;

public class CustomerNoteHashTable : BaseEntity
{
    public CustomerNoteHashTable()
    {
        Id = Ulid.NewUlid();
        NoteHashTagStatusType = StatusType.Show;
        CustomerNoteHashTags = new HashSet<CustomerNoteHashTag>();
    }

    public Ulid Id { get; set; }
    public string Title { get; set; }
    public StatusType NoteHashTagStatusType { get; set; }
    public Ulid IdBusiness { get; set; }
    public virtual Business? IdBusinessNavigation { get; set; }
    
    public virtual ICollection<CustomerNoteHashTag>? CustomerNoteHashTags { get; set; }
}