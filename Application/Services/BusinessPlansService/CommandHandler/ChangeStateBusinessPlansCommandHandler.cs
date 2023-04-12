namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct ChangeStateBusinessPlansCommandHandler : IRequestHandler<ChangeStateBusinessPlansCommand, BusinessPlan?>
{
    private readonly IBusinessPlanRepository _repository;

    public ChangeStateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan?> Handle(ChangeStateBusinessPlansCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusAsync(request.Status, request.BusinessPlansId);
}