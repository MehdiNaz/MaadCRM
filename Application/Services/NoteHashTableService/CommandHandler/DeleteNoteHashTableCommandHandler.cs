namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct DeleteNoteHashTableCommandHandler : IRequestHandler<DeleteNoteHashTableCommand, Result<CustomerNoteHashTableResponse>>
{
    private readonly INoteHashTableRepository _repository;

    public DeleteNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(DeleteNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteNoteHashTableAsync(request.Id)).Match(result => new Result<CustomerNoteHashTableResponse>(result), exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}