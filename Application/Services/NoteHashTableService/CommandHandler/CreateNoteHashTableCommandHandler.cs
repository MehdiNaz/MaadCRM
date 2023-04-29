namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct CreateNoteHashTableCommandHandler : IRequestHandler<CreateNoteHashTableCommand, Result<CustomerNoteHashTableResponse>>
{
    private readonly INoteHashTableRepository _repository;

    public CreateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(CreateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateNoteHashTableCommand item = new()
            {
                Title = request.Title,
                BusinessId = request.BusinessId
            };
            return (await _repository.CreateNoteHashTableAsync(item)).
                Match(result => new Result<CustomerNoteHashTableResponse>(result),
                exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}