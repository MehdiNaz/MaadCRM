﻿namespace Application.Services.NoteHashTableService.Commands;

public struct UpdateNoteHashTableCommand : IRequest<NoteHashTable>
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Ulid BusinessId { get; set; }
}