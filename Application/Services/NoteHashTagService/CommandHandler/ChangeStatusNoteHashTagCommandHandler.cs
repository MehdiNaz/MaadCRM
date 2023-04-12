namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct ChangeStatusNoteHashTagCommandHandler : IRequestHandler<ChangeStatusNoteHashTagCommand, NoteHashTag?>
{
    private readonly INoteHashTagRepository _repository;

    public ChangeStatusNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag?> Handle(ChangeStatusNoteHashTagCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusNoteHashTagByIdAsync(request.NoteHashTagStatus, request.NoteHashTagId);
}