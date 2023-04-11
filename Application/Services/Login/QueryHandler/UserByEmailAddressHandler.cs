namespace Application.Services.Login.QueryHandler;

public class GetUserByEmailAddressHandler : IRequestHandler<UserByEmailAddressQuery, IdentityUser?>
{
    private readonly ILoginRerpository _repository;


    public GetUserByEmailAddressHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<IdentityUser?> Handle(UserByEmailAddressQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByEmailAddress(request);
}