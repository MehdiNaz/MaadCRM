namespace Application.Services.Login.QueryHandler;

public class GetUserByPhoneNumberHandler : IRequestHandler<UserByPhoneNumberQuery, Result<bool>>
{
    private readonly ILoginRepository _repository;
    private readonly IMediator _mediator;

    public GetUserByPhoneNumberHandler(ILoginRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<Result<bool>> Handle(UserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var resultCheckExistByPhone = await _repository.CheckExistByPhone(request);

            if (resultCheckExistByPhone.IsFaulted)
            {
                var resultRegisterUserCommand = _mediator.Send(new RegisterUserCommand
                {
                    Phone = request.Phone
                }, cancellationToken);

                // TODO: add log
                // Console.WriteLine(resultRegisterUserCommand.Result);

                if (resultRegisterUserCommand.Result.IsFaulted)
                    return new Result<bool>(resultRegisterUserCommand.Exception);
            }

            var resultSendVerifyCommand = _mediator.Send(new SendVerifyCommand
            {
                Phone = request.Phone
            }, cancellationToken);

            return resultSendVerifyCommand.Result.IsFaulted ? 
                new Result<bool>(resultSendVerifyCommand.Exception) 
                : new Result<bool>(resultSendVerifyCommand.Result.IsSuccess);
        }
        catch (Exception e)
        {
            return new Result<bool>(new Exception(e.Message));
        }
    }
}