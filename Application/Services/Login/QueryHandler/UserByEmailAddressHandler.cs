namespace Application.Services.Login.QueryHandler;

public class GetUserByEmailAddressHandler : IRequestHandler<UserByEmailAddressQuery, Result<User>>
{
    private readonly ILoginRepository _repository;


    public GetUserByEmailAddressHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<User>> Handle(UserByEmailAddressQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByEmailAddress(request);
}