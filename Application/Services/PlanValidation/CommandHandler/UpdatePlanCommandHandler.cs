namespace Application.Services.PlanValidation.CommandHandler;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Plan>
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
            DayDurations = request.Days,
            CountOfUsers = request.KarbarCount
        };
        await _repository.UpdatePlanAsync(item, request.PlanId);
        return item;
    }
}