namespace Application.Services.PlanService.QueryHandler;

public readonly struct PlanByIdHandler : IRequestHandler<PlanByIdQuery, Plan?>
{
    private readonly IPlanRepository _repository;

    public PlanByIdHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan?> Handle(PlanByIdQuery request, CancellationToken cancellationToken)
    => await _repository.GetPlansByIdAsync(request.PlanId);
}