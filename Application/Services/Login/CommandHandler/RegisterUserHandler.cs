namespace Application.Services.Login.CommandHandler;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<bool>>
{
    private readonly ILoginRepository _repository;

    public RegisterUserHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.RegisterUser(request);
            return result.Match(
                resultCode => new Result<bool>(resultCode), 
                error => new Result<bool>(error));
        }
        catch (Exception e)
        {
            return new Result<bool>(new Exception(e.Message));
        }
    }
}