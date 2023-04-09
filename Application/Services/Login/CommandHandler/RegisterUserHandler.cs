using Application.Services.Login.Commands;
using MediatR;

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
        return await _repository.RegisterUser(request);
    }
}