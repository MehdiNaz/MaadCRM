namespace Application.Services.Login.QueryHandler;

public class GetUserByPhoneNumberHandler : IRequestHandler<GetUserByPhoneNumberQuery, IdentityUser?>
{
    private readonly ILoginOperation _repository;

    public GetUserByPhoneNumberHandler(ILoginOperation repository)
    {
        _repository = repository;
    }

    public async Task<IdentityUser?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        // RequestLoginByPhone item = new()
        // {
        //     Phone = request.Phone
        // };
        return await _repository.CheckExistPhone(request);
    }
}