namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct UpdateNoteHashTableCommandHandler : IRequestHandler<UpdateNoteHashTableCommand, Result<CustomerNoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public UpdateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTable>> Handle(UpdateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateNoteHashTableCommand item = new()
            {
                Id = request.Id,
                Title = request.Title,
                BusinessId = request.BusinessId
            };
            return (await _repository.UpdateNoteHashTableAsync(item))
                .Match(result => new Result<CustomerNoteHashTable>(result),
                exception => new Result<CustomerNoteHashTable>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new Exception(e.Message));
        }
    }
}