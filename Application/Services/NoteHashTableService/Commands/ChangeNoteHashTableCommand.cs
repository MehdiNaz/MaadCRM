﻿namespace Application.Services.NoteHashTableService.Commands;

public struct ChangeNoteHashTableCommand : IRequest<NoteHashTable>
{
    public Ulid Id { get; set; }
    public Status NoteHashTagStatus { get; set; }
}