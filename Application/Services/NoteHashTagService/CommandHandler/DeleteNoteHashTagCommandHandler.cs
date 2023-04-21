namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct DeleteNoteHashTagCommandHandler : IRequestHandler<DeleteNoteHashTagCommand, CustomerNoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public DeleteNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTag> Handle(DeleteNoteHashTagCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteNoteHashTagAsync(request))!;
}