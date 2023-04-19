namespace Domain.Models.Customers.Notes;

public class NoteHashTag : BaseEntity
{
    public NoteHashTag()
    {
        Id = Ulid.NewUlid();
        NoteHashTagStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public Ulid NoteHashTableId { get; set; }
    public Status NoteHashTagStatus { get; set; }
    public NoteHashTable NoteHashTable { get; set; }
}