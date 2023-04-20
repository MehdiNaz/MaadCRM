namespace Application.Services.NoteHashTagService.Commands;

public struct UpdateNoteHashTagCommand : IRequest<NoteHashTag>
{
    public Ulid Id { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public Ulid NoteHashTableId { get; set; }
}