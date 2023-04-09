namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct ChangeStatusBusinessPlansHandler : IRequestHandler<ChangeStatusBusinessPlansQuery, bool>
{
    private readonly IBusinessPlanRepository _repository;

    public ChangeStatusBusinessPlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ChangeStatusBusinessPlansQuery request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusAsync(request.Status, request.BusinessPlansId);
}