namespace Application.Services.UsersPlansService.QueryHandler;

public class GetUsersPlansByIdHandler : IRequestHandler<GetUsersPlansByIdQuery, ICollection<ResponseUsersPlans?>>
{
    private readonly IUsersPlansRepository _repository;

    public GetUsersPlansByIdHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ResponseUsersPlans?>> Handle(GetUsersPlansByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetUsersPlansByIdAsync(request.UserId);
}