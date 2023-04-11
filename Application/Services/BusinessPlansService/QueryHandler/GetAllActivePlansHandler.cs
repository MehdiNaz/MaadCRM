namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetAllActivePlansHandler : IRequestHandler<AllActivePlansQuery, ICollection<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public GetAllActivePlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<BusinessPlan>> Handle(AllActivePlansQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllActivePlansAsync(request.BusinessId)).ToList()!;
}