namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct DeleteBusinessPlansCommandHandler : IRequestHandler<DeleteBusinessPlansCommand, BusinessPlan>
{
    private readonly IBusinessPlanRepository _repository;

    public DeleteBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan> Handle(DeleteBusinessPlansCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteBusinessPlansAsync(request))!;
}