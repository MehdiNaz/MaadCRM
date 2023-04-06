namespace Application.Services.UsersPlansService.QueryHandler;

public class GetTheLatestPlanHandler : IRequestHandler<GetTheLatestPlanQuery, UsersPlans>
{
    private readonly IUsersPlansRepository _repository;

    public GetTheLatestPlanHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsersPlans> Handle(GetTheLatestPlanQuery request, CancellationToken cancellationToken)
        => (await _repository.GetTheLatestPlanAsync())!;
}