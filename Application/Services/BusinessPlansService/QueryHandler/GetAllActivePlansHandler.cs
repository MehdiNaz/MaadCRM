namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct GetAllActivePlansHandler : IRequestHandler<AllActivePlansQuery, Result<ICollection<BusinessPlan>>>
{
    private readonly IBusinessPlanRepository _repository;

    public GetAllActivePlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<BusinessPlan>>> Handle(AllActivePlansQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.GetAllActivePlansAsync(request.BusinessId);
            return resultVerifyCode.Match(result => new Result<ICollection<BusinessPlan>>(result), exception => new Result<ICollection<BusinessPlan>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<BusinessPlan>>(new Exception(e.Message));
        }
    }
}