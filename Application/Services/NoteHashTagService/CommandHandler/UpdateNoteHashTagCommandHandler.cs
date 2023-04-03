namespace Application.Services.NoteHashTagService.CommandHandler;

public class UpdateNoteHashTagCommandHandler : IRequestHandler<UpdateNoteHashTagCommand, NoteHashTag>
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
            Title = request.Title,
            CustomerNoteId = request.CustomerNoteId
        };
        await _repository.UpdateNoteHashTagAsync(item, request.NoteHashTagId);
        return item;

    }
}