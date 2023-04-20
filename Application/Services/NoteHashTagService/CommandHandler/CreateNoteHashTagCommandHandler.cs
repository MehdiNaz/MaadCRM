namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct CreateNoteHashTagCommandHandler : IRequestHandler<CreateNoteHashTagCommand, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public CreateNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(CreateNoteHashTagCommand request, CancellationToken cancellationToken)
    {
        CreateNoteHashTagCommand item = new()
        {
            CustomerNoteId = request.CustomerNoteId,
            NoteHashTableId = request.NoteHashTableId
        };
        return await _repository.CreateNoteHashTagAsync(item);
    }
}