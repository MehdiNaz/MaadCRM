namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct ChangeNoteHashTableCommandHandler : IRequestHandler<ChangeStatusNoteHashTableCommand, CustomerNoteHashTable>
{
    private readonly INoteHashTableRepository _repository;

    public ChangeNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTable> Handle(ChangeStatusNoteHashTableCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusNoteHashTableByIdAsync(request);
}