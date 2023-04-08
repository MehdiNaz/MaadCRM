namespace Application.Services.Login.QueryHandler;

public class GetUserByPhoneNumberHandler : IRequestHandler<UserByPhoneNumberQuery, IdentityUser?>
{
    private readonly ILoginOperation _repository;

    public GetUserByPhoneNumberHandler(ILoginOperation repository)
    {
        _repository = repository;
    }

    public async Task<IdentityUser?> Handle(UserByPhoneNumberQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByPhone(request);
}