namespace Domain.Models.Customers.Notes;

public class CustomerNoteHashTable : BaseEntity
{
    public CustomerNoteHashTable()
    {
        Id = Ulid.NewUlid();
        NoteHashTagStatus = Status.Show;
        CustomerNoteHashTags = new HashSet<CustomerNoteHashTag>();
    }

    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Status NoteHashTagStatus { get; set; }
    public Ulid IdBusiness { get; set; }
    public virtual Business? IdBusinessNavigation { get; set; }
    
    public virtual ICollection<CustomerNoteHashTag>? CustomerNoteHashTags { get; set; }
}