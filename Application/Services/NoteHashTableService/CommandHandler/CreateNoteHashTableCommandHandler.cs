namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct CreateNoteHashTableCommandHandler : IRequestHandler<CreateNoteHashTableCommand, Result<CustomerNoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public CreateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTable>> Handle(CreateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateNoteHashTableCommand item = new()
            {
                Title = request.Title,
                BusinessId = request.BusinessId
            };
            return (await _repository.CreateNoteHashTableAsync(item)).
                Match(result => new Result<CustomerNoteHashTable>(result),
                exception => new Result<CustomerNoteHashTable>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new Exception(e.Message));
        }
    }
}