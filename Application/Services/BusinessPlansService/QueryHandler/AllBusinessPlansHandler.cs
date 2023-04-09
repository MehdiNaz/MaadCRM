namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct AllBusinessPlansHandler : IRequestHandler<AllBusinessPlansQuery, ICollection<BusinessPlans?>>
{
    private readonly IBusinessPlanRepository _repository;

    public AllBusinessPlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<BusinessPlans?>> Handle(AllBusinessPlansQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllBusinessPlansByBusinessIdAsync(request.BusinessId)).ToList();
}