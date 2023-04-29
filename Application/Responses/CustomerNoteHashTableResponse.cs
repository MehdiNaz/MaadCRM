namespace Application.Responses;

public struct CustomerNoteHashTableResponse
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Status NoteHashTagStatus { get; set; }
    public DateTime CreationDate { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string UserFamily { get; set; }
}
