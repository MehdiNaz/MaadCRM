namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct CreateBusinessPlansCommandHandler : IRequestHandler<CreateBusinessPlansCommand, BusinessPlan>
{
    private readonly IBusinessPlanRepository _repository;


    public CreateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan> Handle(CreateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        BusinessPlan item = new()
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
