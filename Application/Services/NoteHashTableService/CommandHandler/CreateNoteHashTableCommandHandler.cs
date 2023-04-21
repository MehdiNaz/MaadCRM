namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct CreateNoteHashTableCommandHandler : IRequestHandler<CreateNoteHashTableCommand, CustomerNoteHashTable>
{
    private readonly INoteHashTableRepository _repository;

    public CreateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTable> Handle(CreateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        CreateNoteHashTableCommand item = new()
        {
            Title = request.Title,
            BusinessId = request.BusinessId
        };
        return await _repository.CreateNoteHashTableAsync(item);
    }
}