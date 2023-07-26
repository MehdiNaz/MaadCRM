using Domain.Models.Businesses.Plans;

namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct DeleteBusinessPlansCommandHandler : IRequestHandler<DeleteBusinessPlansCommand, Result<BusinessPlan>>
{
    private readonly IBusinessPlanRepository _repository;

    public DeleteBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BusinessPlan>> Handle(DeleteBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.DeleteBusinessPlansAsync(request.BusinessPlansId);
            return resultVerifyCode.Match(result => new Result<BusinessPlan>(result), exception => new Result<BusinessPlan>(exception));
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new Exception(e.Message));
        }
    }
}