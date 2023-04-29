namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct DeleteNoteHashTableCommandHandler : IRequestHandler<DeleteNoteHashTableCommand, Result<CustomerNoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public DeleteNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTable>> Handle(DeleteNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteNoteHashTableAsync(request.Id)).Match(result => new Result<CustomerNoteHashTable>(result), exception => new Result<CustomerNoteHashTable>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new Exception(e.Message));
        }
    }
}