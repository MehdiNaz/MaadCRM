namespace Application.Services.NoteHashTagService.Commands;

public struct CreateNoteHashTagCommand : IRequest<CustomerNoteHashTag>
{
    public Ulid CustomerNoteId { get; set; }
    public Ulid NoteHashTableId { get; set; }
}