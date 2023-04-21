namespace Application.Services.NoteHashTagService.CommandHandler;

public readonly struct ChangeStatusNoteHashTagCommandHandler : IRequestHandler<ChangeStatusNoteHashTagCommand, CustomerNoteHashTag?>
{
    private readonly INoteHashTagRepository _repository;

    public ChangeStatusNoteHashTagCommandHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteHashTag?> Handle(ChangeStatusNoteHashTagCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusNoteHashTagByIdAsync(request);
}