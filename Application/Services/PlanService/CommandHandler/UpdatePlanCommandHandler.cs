namespace Application.Services.PlanService.CommandHandler;

public readonly struct UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Plan>
{
    private readonly IPlanRepository _repository;

    public UpdatePlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        Plan item = new()
        {
            PlanId = request.PlanId,
            PlanName = request.PlanName,
            UserId = request.UserId,
            CountOfUsers = request.CountOfUsers,
            PriceOfUsers = request.PriceOfUsers,
            CountOfDay = request.CountOfDay,
            PriceOfDay = request.PriceOfDay
        };
        await _repository.UpdatePlanAsync(item);
        return item;
    }
}
