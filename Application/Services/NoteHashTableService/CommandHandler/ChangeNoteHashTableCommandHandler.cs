namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct ChangeNoteHashTableCommandHandler : IRequestHandler<ChangeStatusNoteHashTableCommand, Result<CustomerNoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public ChangeNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTable>> Handle(ChangeStatusNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusNoteHashTableByIdAsync(request))
                .Match(result => new Result<CustomerNoteHashTable>(result),
                exception => new Result<CustomerNoteHashTable>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new Exception(e.Message));
        }
    }
}