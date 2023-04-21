namespace Application.Services.NoteHashTagService.Commands;

public struct DeleteNoteHashTagCommand : IRequest<CustomerNoteHashTag>
{
    public Ulid Id { get; set; }
}