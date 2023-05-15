namespace Application.Responses;

public struct CustomerNoteHashTableResponse
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public StatusType NoteHashTagStatusType { get; set; }
    public DateTime CreationDate { get; set; }
    public string IdUser { get; set; }
    public string Username { get; set; }
    public string UserFamily { get; set; }
}
