﻿namespace Application.Services.NoteHashTagService.Commands;

public struct CreateNoteHashTagCommand : IRequest<NoteHashTag>
{
    public Ulid CustomerNoteId { get; set; }
}