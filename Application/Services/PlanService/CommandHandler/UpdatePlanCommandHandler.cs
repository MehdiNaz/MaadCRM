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
        UpdatePlanCommand item = new()
        {
            Id = request.Id,
            PlanName = request.PlanName,
            UserId = request.UserId,
            CountOfUsers = request.CountOfUsers,
            PriceOfUsers = request.PriceOfUsers,
            CountOfDay = request.CountOfDay,
            PriceOfDay = request.PriceOfDay,
            FinalPrice = request.FinalPrice
        };
        return await _repository.UpdatePlanAsync(item);
    }
}
