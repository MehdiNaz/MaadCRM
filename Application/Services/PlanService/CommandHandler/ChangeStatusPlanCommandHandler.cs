namespace Application.Services.PlanService.CommandHandler;

public readonly struct ChangeStatusPlanCommandHandler : IRequestHandler<ChangeStatusPlanCommand, Plan?>
{
    private readonly IPlanRepository _repository;

    public ChangeStatusPlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan?> Handle(ChangeStatusPlanCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusPlansByIdAsync(request.PlanStatus, request.PlanId);
}