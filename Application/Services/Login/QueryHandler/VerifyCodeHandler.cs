namespace Application.Services.Login.QueryHandler;

public class VerifyCodeHandler : IRequestHandler<VerifyCodeQuery, IdentityUser?>
{
    private readonly ILoginRerpository _repository;

    public VerifyCodeHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }
    public async Task<IdentityUser?> Handle(VerifyCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.VerifyCode(request);
    }
}