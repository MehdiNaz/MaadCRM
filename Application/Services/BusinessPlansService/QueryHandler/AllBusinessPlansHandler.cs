namespace Application.Services.BusinessPlansService.QueryHandler;

public readonly struct AllBusinessPlansHandler : IRequestHandler<AllBusinessPlansQuery, Result<ICollection<BusinessPlan>>>
{
    private readonly IBusinessPlanRepository _repository;

    public AllBusinessPlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<BusinessPlan>>> Handle(AllBusinessPlansQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.GetAllBusinessPlansByBusinessIdAsync(request.BusinessId);
            return resultVerifyCode.Match(result => new Result<ICollection<BusinessPlan>>(result), exception => new Result<ICollection<BusinessPlan>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<BusinessPlan>>(new Exception(e.Message));
        }
    }
}