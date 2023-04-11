namespace Application.Services.SanAtService.CommandHandlers;

public readonly struct UpdateSanAtCommandHandler : IRequestHandler<UpdateSanAtCommand, SanAt>
{
    private readonly ISanAtRepository _repository;

    public UpdateSanAtCommandHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt> Handle(UpdateSanAtCommand request, CancellationToken cancellationToken)
    {
        SanAt item = new()
        {
            SanAtName = request.SanAtName,
            UserId = request.UserId,
        };
        await _repository.UpdateSanAtsAsync(item, request.SanAtId);
        return item;
    }
}
