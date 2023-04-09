namespace Application.Services.BusinessPlansService.QueryHandler;

public class GetUsersPlansByIdHandler : IRequestHandler<BusinessPlansByIdQuery, BusinessPlans?>
{
    private readonly IBusinessPlanRepository _repository;

    public GetUsersPlansByIdHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlans?> Handle(BusinessPlansByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetBusinessPlansByIdAsync(request.BusinessPlansId));
}