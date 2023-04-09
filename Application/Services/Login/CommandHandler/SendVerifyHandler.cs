using Application.Services.Login.Commands;
using MediatR;

namespace Application.Services.Login.CommandHandler;

public class SendVerifyHandler : IRequestHandler<SendSMSCommand, bool>
{
    private readonly ILoginRerpository _repository;

    public SendVerifyHandler(ILoginRerpository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(SendSMSCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.SendVerifyCode(request);
        return result;
    }
}