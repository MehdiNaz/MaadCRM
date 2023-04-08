namespace Application.Services.PlanService.QueryHandler;

public class GetPlanByIdHandler : IRequestHandler<PlanByIdQuery, Plan?>
{
    private readonly IPlanRepository _repository;

    public GetPlanByIdHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan?> Handle(PlanByIdQuery request, CancellationToken cancellationToken)
    => await _repository.GetPlansByIdAsync(request.PlanId);
}