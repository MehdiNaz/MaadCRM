namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct ChangeNoteHashTableCommandHandler : IRequestHandler<ChangeStatusNoteHashTableCommand, Result<CustomerNoteHashTableResponse>>
{
    private readonly INoteHashTableRepository _repository;

    public ChangeNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(ChangeStatusNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusNoteHashTableByIdAsync(request))
                .Match(result => new Result<CustomerNoteHashTableResponse>(result),
                exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}