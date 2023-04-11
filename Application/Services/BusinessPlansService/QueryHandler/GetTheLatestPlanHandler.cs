namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetTheLatestPlanHandler : IRequestHandler<TheLatestPlanQuery, BusinessPlan>
{
    private readonly IBusinessPlanRepository _repository;

    public GetTheLatestPlanHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan> Handle(TheLatestPlanQuery request, CancellationToken cancellationToken)
        => (await _repository.GetTheLatestPlanAsync(request.BusinessId))!;
}