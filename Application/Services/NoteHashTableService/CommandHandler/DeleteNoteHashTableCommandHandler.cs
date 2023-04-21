namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct DeleteNoteHashTableCommandHandler : IRequestHandler<DeleteNoteHashTableCommand, CustomerNoteHashTable>
{
    private readonly INoteHashTableRepository _repository;

    public DeleteNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTable> Handle(DeleteNoteHashTableCommand request, CancellationToken cancellationToken)
        => await _repository.DeleteNoteHashTableAsync(request);
}