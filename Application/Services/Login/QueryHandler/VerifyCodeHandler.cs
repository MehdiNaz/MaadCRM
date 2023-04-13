using LanguageExt;

namespace Application.Services.Login.QueryHandler;

public class VerifyCodeHandler : IRequestHandler<VerifyCodeQuery, Option<User>>
{
    private readonly ILoginRepository _repository;

    public VerifyCodeHandler(ILoginRepository repository)
    {
        _repository = repository;
    }
    public async Task<Option<User>> Handle(VerifyCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.VerifyCode(request);
    }
}