namespace Application.Services.UsersPlansService.QueryHandler;

public class GetAllActivePlansHandler : IRequestHandler<GetAllActivePlansQuery, ICollection<UsersPlans>>
{
    private readonly IUsersPlansRepository _repository;

    public GetAllActivePlansHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<UsersPlans>> Handle(GetAllActivePlansQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllActivePlansAsync())!;
}