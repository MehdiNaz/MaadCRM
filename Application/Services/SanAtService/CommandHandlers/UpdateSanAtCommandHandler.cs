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
        UpdateSanAtCommand item = new()
        {
            Id = request.Id,
            SanAtName = request.SanAtName,
            UserId = request.UserId,
        };
        return await _repository.UpdateSanAtsAsync(item);
    }
}
