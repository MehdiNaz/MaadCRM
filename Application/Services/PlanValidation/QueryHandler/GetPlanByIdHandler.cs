namespace Application.Services.PlanValidation.QueryHandler;

public class GetPlanByIdHandler : IRequestHandler<GetPlanByIdQuery, Plan?>
{
    private readonly IPlanRepository _repository;

    public GetPlanByIdHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan?> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
    => await _repository.GetPlansByIdAsync(request.PlanId);
}