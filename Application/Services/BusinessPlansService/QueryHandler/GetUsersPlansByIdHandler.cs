namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetUsersPlansByIdHandler : IRequestHandler<BusinessPlansByIdQuery, BusinessPlan?>
{
    private readonly IBusinessPlanRepository _repository;

    public GetUsersPlansByIdHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan?> Handle(BusinessPlansByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetBusinessPlansByIdAsync(request.BusinessPlansId));
}