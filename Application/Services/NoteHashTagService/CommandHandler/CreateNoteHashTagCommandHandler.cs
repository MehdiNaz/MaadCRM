namespace Application.Services.NoteHashTagService.CommandHandler;

public class CreateNoteHashTagCommandHandler : IRequestHandler<CreateNoteHashTagCommand, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public CreateNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(CreateNoteHashTagCommand request, CancellationToken cancellationToken)
    {
        NoteHashTag item = new()
        {
            Title = request.Title,
            CustomerNoteId = request.CustomerNoteId
        };
        await _repository.CreateNoteHashTagAsync(item);
        return item;
    }
}