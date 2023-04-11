namespace Application.Services.Login.CommandHandler;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly ILoginRerpository _repository;

    public RegisterUserHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.RegisterUser(request);
        return result;
    }
}