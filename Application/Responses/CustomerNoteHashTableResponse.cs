namespace Application.Responses;

public struct CustomerNoteHashTableResponse
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Status NoteHashTagStatus { get; set; }
}
