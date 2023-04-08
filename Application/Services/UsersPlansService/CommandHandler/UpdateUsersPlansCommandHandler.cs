namespace Application.Services.UsersPlansService.CommandHandler;

public class UpdateUsersPlansCommandHandler : IRequestHandler<UpdateUsersPlansCommand, UsersPlans>
{
    private readonly IUsersPlansRepository _repository;

    public UpdateUsersPlansCommandHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsersPlans> Handle(UpdateUsersPlansCommand request, CancellationToken cancellationToken)
    {
        UsersPlans item = new()
        {
            UserId = request.UserId,
            PlanId = request.PlanId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        await _repository.UpdateUsersPlansAsync(item, request.UsersPlansId);
        return item;
    }
}