namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct UpdateNoteHashTagCommandHandler : IRequestHandler<UpdateNoteHashTagCommand, CustomerNoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public UpdateNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTag> Handle(UpdateNoteHashTagCommand request, CancellationToken cancellationToken)
    {
        UpdateNoteHashTagCommand item = new()
        {
            CustomerNoteId = request.CustomerNoteId,
            NoteHashTableId = request.NoteHashTableId
        };
        return await _repository.UpdateNoteHashTagAsync(item);
    }
}