﻿namespace Application.Services.BusinessPlansService.CommandHandler;

public readonly struct UpdateBusinessPlansCommandHandler : IRequestHandler<UpdateBusinessPlansCommand, BusinessPlan>
{
    private readonly IBusinessPlanRepository _repository;

    public UpdateBusinessPlansCommandHandler(IBusinessPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<BusinessPlan> Handle(UpdateBusinessPlansCommand request, CancellationToken cancellationToken)
    {
        BusinessPlan item = new()
        {
            BusinessPlansId = request.BusinessPlansId,
            PlanId = request.PlanId,
            BusinessId = request.BusinessId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        await _repository.UpdateBusinessPlansAsync(item);
        return item;
    }
}
