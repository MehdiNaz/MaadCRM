namespace Application.Services.NoteHashTagService.CommandHandler;

public class DeleteNoteHashTagCommandHandler : IRequestHandler<DeleteNoteHashTagCommand, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public DeleteNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(DeleteNoteHashTagCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteNoteHashTagAsync(request.NoteHashTagId))!;
}