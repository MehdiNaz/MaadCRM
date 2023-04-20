namespace Application.Services.PlanService.CommandHandler;

public readonly struct CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, Plan>
{
    private readonly IPlanRepository _repository;

    public CreatePlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        CreatePlanCommand item = new()
        {
            UserId = request.UserId,
            PlanName = request.PlanName,
            CountOfUsers = request.CountOfUsers,
            PriceOfUsers = request.PriceOfUsers,
            CountOfDay = request.CountOfDay,
            PriceOfDay = request.PriceOfDay,
            FinalPrice = request.FinalPrice
        };
        return await _repository.CreatePlanAsync(item);
    }
}
