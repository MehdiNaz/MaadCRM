namespace Domain.Models.Customers.Notes;

public class NoteHashTable : BaseEntity
{
    public NoteHashTable()
    {
        Id = Ulid.NewUlid();
        NoteHashTagStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Status NoteHashTagStatus { get; set; }
    public Ulid BusinessId { get; set; }
}