namespace Application.Services.Login.QueryHandler;

public class VerifyCodeHandler : IRequestHandler<UserByEmailAddressQuery, IdentityUser?>
{
    public async Task<IdentityUser?> Handle(UserByEmailAddressQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}