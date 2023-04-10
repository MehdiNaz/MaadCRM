using Application.Interfaces.Account;

namespace Application.Services.Login.QueryHandler;

public class UserByPhoneAndPasswordHandler : IRequestHandler<UserByPhoneAndPasswordQuery, bool>
{
    private readonly ILoginRerpository _repository;

    public UserByPhoneAndPasswordHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UserByPhoneAndPasswordQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByPhoneAndPassword(request);
}