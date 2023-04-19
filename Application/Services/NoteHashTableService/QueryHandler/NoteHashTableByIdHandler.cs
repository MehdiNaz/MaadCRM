namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct NoteHashTableByIdHandler : IRequestHandler<NoteHashTableByIdQuery, NoteHashTable>
{
    private readonly INoteHashTableRepository _repository;

    public NoteHashTableByIdHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTable> Handle(NoteHashTableByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetNoteHashTableByIdAsync(request.Id);
}