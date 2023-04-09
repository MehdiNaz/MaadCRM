namespace Application.Services.BusinessPlansService.CommandHandler;

public class DeleteBusinessPlansCommandHandler : IRequestHandler<DeleteBusinessPlansCommand, BusinessPlans>
{
    private readonly IBusinessPlanRepository _repository;

    public DeleteBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlans> Handle(DeleteBusinessPlansCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteBusinessPlansAsync(request.BusinessPlansId))!;
}