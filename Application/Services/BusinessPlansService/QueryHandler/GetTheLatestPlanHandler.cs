namespace Application.Services.BusinessPlansService.QueryHandler;

public class GetTheLatestPlanHandler : IRequestHandler<TheLatestPlanQuery, BusinessPlans>
{
    private readonly IBusinessPlanRepository _repository;

    public GetTheLatestPlanHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlans> Handle(TheLatestPlanQuery request, CancellationToken cancellationToken)
        => (await _repository.GetTheLatestPlanAsync(request.BusinessPlansId))!;
}