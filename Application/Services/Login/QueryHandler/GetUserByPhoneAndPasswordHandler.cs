namespace Application.Services.Login.QueryHandler;

public class GetUserByPhoneAndPasswordHandler : IRequestHandler<GetUserByPhoneAndPasswordQuery, bool>
{
    private readonly ILoginOperation _repository;

    public GetUserByPhoneAndPasswordHandler(ILoginOperation repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(GetUserByPhoneAndPasswordQuery request, CancellationToken cancellationToken)
        => await _repository.CheckExistByPhoneAndPassword(request);
}