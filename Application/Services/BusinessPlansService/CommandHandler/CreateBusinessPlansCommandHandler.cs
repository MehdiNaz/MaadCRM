namespace Application.Services.BusinessPlansService.CommandHandler;

public class CreateBusinessPlansCommandHandler : IRequestHandler<CreateBusinessPlansCommand, BusinessPlans>
{
    private readonly IBusinessPlanRepository _repository;


    public CreateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlans> Handle(CreateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        BusinessPlans item = new()
        {
            PlanId = request.PlanId,
            BusinessId = request.BusinessId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        await _repository.CreateBusinessPlansAsync(item);
        return item;
    }
}
