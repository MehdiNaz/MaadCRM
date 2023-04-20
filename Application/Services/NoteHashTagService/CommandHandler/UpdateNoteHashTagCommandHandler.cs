namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct UpdateNoteHashTagCommandHandler : IRequestHandler<UpdateNoteHashTagCommand, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public UpdateNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(UpdateNoteHashTagCommand request, CancellationToken cancellationToken)
    {
        UpdateNoteHashTagCommand item = new()
        {
            Id = request.Id,
            CustomerNoteId = request.CustomerNoteId,
            NoteHashTableId = request.NoteHashTableId
        };
        return await _repository.UpdateNoteHashTagAsync(item);
    }
}