namespace Application.Services.SanAtService.CommandHandlers;

public readonly struct ChangeStatusSanAtCommandHandler : IRequestHandler<ChangeStatusSanAtCommand, SanAt?>
{
    private readonly ISanAtRepository _repository;

    public ChangeStatusSanAtCommandHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt?> Handle(ChangeStatusSanAtCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusSanAtsByIdAsync(request);
}