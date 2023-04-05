namespace Application.Services.Login.QueryHandler;

public class GetUserByEmailAddressHandler : IRequestHandler<GetUserByEmailAddressQuery, IdentityUser?>
{
    private readonly ILoginOperation _repository;


    public GetUserByEmailAddressHandler(ILoginOperation repository)
    {
        _repository = repository;
    }

    public async Task<IdentityUser?> Handle(GetUserByEmailAddressQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByEmailAddress(request);
}