using Domain.Models.IdentityModels;

namespace Application.Services.Login.QueryHandler;

public class VerifyCodeHandler : IRequestHandler<VerifyCodeQuery, User?>
{
    private readonly ILoginRerpository _repository;

    public VerifyCodeHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }
    public async Task<User?> Handle(VerifyCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.VerifyCode(request);
    }
}