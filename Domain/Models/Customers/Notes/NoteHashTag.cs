namespace Domain.Models.Customers.Notes;

public class NoteHashTag : BaseEntity
{
    public NoteHashTag()
    {
        NoteHashTagId = Ulid.NewUlid();
        NoteHashTagStatus = Status.Show;
    }

    public Ulid NoteHashTagId { get; set; }
    public string Title { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public Status NoteHashTagStatus { get; set; }

    // public CustomerNote CustomerNote { get; set; }
}