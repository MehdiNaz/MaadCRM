namespace Application.Services.Login.QueryHandler;

public class GetUserByPhoneNumberHandler : IRequestHandler<UserByPhoneNumberQuery, IdentityUser?>
{
    private readonly ILoginRerpository _repository;

    public GetUserByPhoneNumberHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<IdentityUser?> Handle(UserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.CheckExistByPhone(request);
        return result;
    }
        
}