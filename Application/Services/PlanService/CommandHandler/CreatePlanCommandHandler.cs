﻿namespace Application.Services.PlanService.CommandHandler;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, Plan>
{
    private readonly IPlanRepository _repository;

    public CreatePlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        Plan item = new()
        {
            PlanName = request.PlanName,
            CountOfUsers = request.CountOfUsers,
            PriceOfUsers = request.PriceOfUsers,
            CountOfDay = request.CountOfDay,
            PriceOfDay = request.PriceOfDay,
        };
        await _repository.CreatePlanAsync(item);
        return item;
    }
}
