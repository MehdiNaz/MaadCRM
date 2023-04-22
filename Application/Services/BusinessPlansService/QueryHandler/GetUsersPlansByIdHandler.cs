namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetUsersPlansByIdHandler : IRequestHandler<BusinessPlansByIdQuery, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public GetUsersPlansByIdHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(BusinessPlansByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.GetBusinessPlansByIdAsync(request.BusinessPlansId);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}