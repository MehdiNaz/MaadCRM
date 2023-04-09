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
        NoteHashTag item = new()
        {
            NoteHashTagId= request.NoteHashTagId,
            Title = request.Title,
            CustomerNoteId = request.CustomerNoteId
        };
        await _repository.UpdateNoteHashTagAsync(item);
        return item;
    }
}