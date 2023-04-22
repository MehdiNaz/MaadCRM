namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct CreateBusinessPlansCommandHandler : IRequestHandler<CreateBusinessPlansCommand, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;


    public CreateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(CreateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateBusinessPlansCommand item = new()
            {
                PlanId = request.PlanId,
                BusinessId = request.BusinessId,
                CountOfDay = request.CountOfDay,
                CountOfUsers = request.CountOfUsers
            };
            var resultVerifyCode = await _repository.CreateBusinessPlansAsync(item);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}
