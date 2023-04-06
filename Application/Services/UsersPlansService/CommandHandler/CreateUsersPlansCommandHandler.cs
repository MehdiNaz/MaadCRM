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
            Days = request.Days,
            UserId = request.UserId,
            PlanId = request.PlanId,
            KarbarCounts = request.KarbarCounts
        };
        await _repository.CreateUsersPlansAsync(item);
        return item;
    }
}