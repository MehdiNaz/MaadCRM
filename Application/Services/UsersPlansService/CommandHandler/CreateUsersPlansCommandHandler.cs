namespace Application.Services.UsersPlansService.CommandHandler;

public class CreateUsersPlansCommandHandler : IRequestHandler<CreateUsersPlansCommand, UsersPlans>
{
    private readonly IUsersPlansRepository _repository;

    public CreateUsersPlansCommandHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsersPlans> Handle(CreateUsersPlansCommand request, CancellationToken cancellationToken)
    {
        UsersPlans item = new()
        {
            UserId = request.UserId,
            PlanId = request.PlanId,
            CountOfDay = request.CountOfDay,
            CountOfUsers = request.CountOfUsers
        };
        await _repository.CreateUsersPlansAsync(item);
        return item;
    }
}