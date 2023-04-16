namespace Application.Services.Login.CommandHandler;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Option<bool>>
{
    private readonly ILoginRepository _repository;

    public RegisterUserHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Option<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.RegisterUser(request);
            return result.Match(resultCode => Option<bool>.Some(resultCode), () => Option<bool>.None);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}