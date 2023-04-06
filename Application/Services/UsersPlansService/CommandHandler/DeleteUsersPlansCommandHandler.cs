namespace Application.Services.UsersPlansService.CommandHandler;

public class DeleteUsersPlansCommandHandler : IRequestHandler<DeleteUsersPlansCommand, UsersPlans>
{
    private readonly IUsersPlansRepository _repository;

    public DeleteUsersPlansCommandHandler(IUsersPlansRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsersPlans> Handle(DeleteUsersPlansCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteUsersPlansAsync(request.UsersPlansId))!;
}