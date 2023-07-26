using Domain.Models.Businesses.Plans;

namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct ChangeStatusBusinessPlansHandler : IRequestHandler<ChangeStatusBusinessPlansQuery, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public ChangeStatusBusinessPlansHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(ChangeStatusBusinessPlansQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.ChangeStatusAsync(request);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}