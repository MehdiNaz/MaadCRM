namespace Application.Services.Login.QueryHandler;

public class UserByPhoneAndPasswordHandler : IRequestHandler<UserByPhoneAndPasswordQuery, bool>
{
    private readonly ILoginOperation _repository;

    public UserByPhoneAndPasswordHandler(ILoginOperation repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UserByPhoneAndPasswordQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByPhoneAndPassword(request);
}