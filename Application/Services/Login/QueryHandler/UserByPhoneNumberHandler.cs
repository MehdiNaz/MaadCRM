using LanguageExt;

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

            if (resultCheckExistByPhone.IsNone)
            {
                var resultRegisterUserCommand = _mediator.Send(new RegisterUserCommand
                {
                    Phone = request.Phone
                }, cancellationToken);

                // TODO: add log
                Console.WriteLine(resultRegisterUserCommand.Result);

                if (resultRegisterUserCommand.Result.IsNone)
                    return new Result<bool>(false);
            }

            var resultSendVerifyCommand = _mediator.Send(new SendVerifyCommand
            {
                Phone = request.Phone
            }, cancellationToken);

            return resultSendVerifyCommand.Result.IsNone ? new Result<bool>(false) : new Result<bool>(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}