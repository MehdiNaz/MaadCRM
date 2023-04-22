using MediatR;

namespace Application.Services.Login.CommandHandler;

public class SendVerifyHandler : IRequestHandler<SendVerifyCommand, Result<bool>>
{
    private readonly ILoginRepository _repository;

    public SendVerifyHandler(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(SendVerifyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.SendVerifyCode(request);
            return result.Match(succ => new Result<bool>(succ), error => new Result<bool>(error));
        }
        catch (Exception e)
        {
            return new Result<bool>(new Exception(e.Message));
        }
        
    }
}