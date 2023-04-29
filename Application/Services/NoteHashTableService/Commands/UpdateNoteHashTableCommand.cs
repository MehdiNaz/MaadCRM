﻿namespace Application.Services.NoteHashTableService.Commands;

public struct UpdateNoteHashTableCommand : IRequest<Result<CustomerNoteHashTable>>
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
}