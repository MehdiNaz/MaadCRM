using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace Application.Services.Login.CommandHandler;

public class SendVerifyHandler : IRequestHandler<SendVerifyCommand, Option<bool>>
{
    private readonly ILoginRepository _repository;

    public SendVerifyHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Option<bool>> Handle(SendVerifyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.SendVerifyCode(request);
            return result.Match(Option<bool>.Some, () => Option<bool>.None);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}