namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetTheLatestPlanHandler : IRequestHandler<TheLatestPlanQuery, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public GetTheLatestPlanHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(TheLatestPlanQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.GetTheLatestPlanAsync(request.BusinessId);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}