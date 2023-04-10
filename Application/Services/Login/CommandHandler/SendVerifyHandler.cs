using Application.Interfaces.Account;
using Application.Services.Login.Commands;
using MediatR;

namespace Application.Services.Login.CommandHandler;

public class SendVerifyHandler : IRequestHandler<SendVerifyCommand, bool>
{
    private readonly ILoginRerpository _repository;

    public SendVerifyHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(SendVerifyCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.SendVerifyCode(request);
        return result;
    }
}