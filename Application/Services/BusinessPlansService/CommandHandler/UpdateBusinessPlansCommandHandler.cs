namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct UpdateBusinessPlansCommandHandler : IRequestHandler<UpdateBusinessPlansCommand, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public UpdateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(UpdateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateBusinessPlansCommand item = new()
            {
                BusinessPlansId = request.BusinessPlansId,
                PlanId = request.PlanId,
                BusinessId = request.BusinessId,
                CountOfDay = request.CountOfDay,
                CountOfUsers = request.CountOfUsers
            };
            var resultVerifyCode = await _repository.UpdateBusinessPlansAsync(item);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}
