namespace Application.Services.PlanValidation.CommandHandler;

public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, Plan>
{
    private readonly IPlanRepository _repository;

    protected DeletePlanCommandHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePlanAsync(request.PlanId))!;
}
