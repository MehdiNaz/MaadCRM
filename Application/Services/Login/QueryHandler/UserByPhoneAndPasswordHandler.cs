namespace Application.Services.Login.QueryHandler;

public class UserByPhoneAndPasswordHandler : IRequestHandler<UserByPhoneAndPasswordQuery, Result<bool>>
{
    private readonly ILoginRepository _repository;

    public UserByPhoneAndPasswordHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(UserByPhoneAndPasswordQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByPhoneAndPassword(request);
}