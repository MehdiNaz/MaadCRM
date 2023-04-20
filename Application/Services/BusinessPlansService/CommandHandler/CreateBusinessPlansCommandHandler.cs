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
        CreateBusinessPlansCommand item = new()
        {
            PlanId = request.PlanId,
            BusinessId = request.BusinessId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        return await _repository.CreateBusinessPlansAsync(item);
    }
}
