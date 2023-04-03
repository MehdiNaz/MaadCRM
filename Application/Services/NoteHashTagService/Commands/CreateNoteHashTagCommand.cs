namespace Application.Services.NoteHashTagService.Commands;

public struct CreateNoteHashTagCommand : IRequest<NoteHashTag>
{
    public string Title { get; set; }
    public Ulid CustomerNoteId { get; set; }
}