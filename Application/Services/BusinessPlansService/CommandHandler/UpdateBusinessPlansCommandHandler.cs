namespace Application.Services.BusinessPlansService.CommandHandler;

public class UpdateBusinessPlansCommandHandler : IRequestHandler<UpdateBusinessPlansCommand, BusinessPlans>
{
    private readonly IBusinessPlanRepository _repository;

    public UpdateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlans> Handle(UpdateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        BusinessPlans item = new()
        {
            BusinessPlansId = request.BusinessPlansId,
            PlanId = request.PlanId,
            BusinessId = request.BusinessId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        await _repository.UpdateBusinessPlansAsync(item);
        return item;
    }
}
