namespace Application.Services.NoteHashTagService.Commands;

public struct UpdateNoteHashTagCommand : IRequest<CustomerNoteHashTag>
{
    public Ulid CustomerNoteId { get; set; }
    public Ulid NoteHashTableId { get; set; }
}