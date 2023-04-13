using LanguageExt;
using LanguageExt.Common;

namespace Application.Services.Login.QueryHandler;

public class VerifyCodeHandler : IRequestHandler<VerifyCodeQuery, Result<User>>
{
    private readonly ILoginRepository _repository;

    public VerifyCodeHandler(ILoginRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<User>> Handle(VerifyCodeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.VerifyCode(request);

            return resultVerifyCode.Match( result => new Result<User>(result), exception =>  new Result<User>(exception) );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}