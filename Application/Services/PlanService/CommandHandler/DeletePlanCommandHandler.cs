namespace Application.Services.PlanService.CommandHandler;

public readonly struct DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, Plan>
{
    private readonly IPlanRepository _repository;

    public DeletePlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePlanAsync(request.PlanId))!;
}
