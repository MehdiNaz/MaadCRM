namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct ChangeStatusBusinessPlansHandler : IRequestHandler<ChangeStatusBusinessPlansQuery, BusinessPlan?>
{
    private readonly IBusinessPlanRepository _repository;

    public ChangeStatusBusinessPlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan?> Handle(ChangeStatusBusinessPlansQuery request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusAsync(request);
}