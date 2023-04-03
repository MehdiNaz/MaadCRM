namespace Domain.Models.Customers.Notes;

public class NoteHashTag : BaseEntity
{
    public NoteHashTag()
    {
        NoteHashTagId = Ulid.NewUlid();
        IsDeleted = Status.NotDeleted;
    }

    public Ulid NoteHashTagId { get; set; }
    public string Title { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public Status IsDeleted { get; set; }


    public CustomerNote CustomerNote { get; set; }
}