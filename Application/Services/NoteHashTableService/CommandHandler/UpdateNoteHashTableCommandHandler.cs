﻿namespace Application.Services.NoteHashTableService.CommandHandler;

public readonly struct UpdateNoteHashTableCommandHandler : IRequestHandler<UpdateNoteHashTableCommand, CustomerNoteHashTable>
{
    private readonly INoteHashTableRepository _repository;

    public UpdateNoteHashTableCommandHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTable> Handle(UpdateNoteHashTableCommand request, CancellationToken cancellationToken)
    {
        UpdateNoteHashTableCommand item = new()
        {
            Id = request.Id,
            Title = request.Title,
            BusinessId = request.BusinessId
        };
        return await _repository.UpdateNoteHashTableAsync(item);
    }
}