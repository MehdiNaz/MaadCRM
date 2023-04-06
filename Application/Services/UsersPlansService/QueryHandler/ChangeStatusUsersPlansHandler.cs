namespace Application.Services.UsersPlansService.QueryHandler;

public class ChangeStatusUsersPlansHandler : IRequestHandler<ChangeStatusUsersPlansQuery, bool>
{
    private readonly IUsersPlansRepository _repository;

    public ChangeStatusUsersPlansHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ChangeStatusUsersPlansQuery request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusAsync(request.Status, request.UserId);
}