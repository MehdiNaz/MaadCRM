namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct UpdateNoteHashTableCommandHandler : IRequestHandler<UpdateNoteHashTableCommand, Result<CustomerNoteHashTableResponse>>
{
    private readonly INoteHashTableRepository _repository;

    public UpdateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(UpdateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateNoteHashTableCommand item = new()
            {
                Id = request.Id,
                Title = request.Title,
            };
            return (await _repository.UpdateNoteHashTableAsync(item))
                .Match(result => new Result<CustomerNoteHashTableResponse>(result),
                exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}