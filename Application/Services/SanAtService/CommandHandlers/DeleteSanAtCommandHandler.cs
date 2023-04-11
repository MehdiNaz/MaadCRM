namespace Application.Services.SanAtService.CommandHandlers;

public readonly struct DeleteSanAtCommandHandler : IRequestHandler<DeleteSanAtCommand, SanAt>
{
    private readonly ISanAtRepository _repository;

    public DeleteSanAtCommandHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt> Handle(DeleteSanAtCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteSanAtsAsync(request.SanAtId))!;
}