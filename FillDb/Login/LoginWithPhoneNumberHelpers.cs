using Application.Services.Login.Queries;
using MediatR;

public class LoginWithPhoneNumberHelpers
{
    private readonly IMediator _mediator;

    public LoginWithPhoneNumberHelpers(IMediator mediator)
    {
        _mediator = mediator;
    }

    public bool LoginWithPhoneNumberTest()
    {

        var resultUserByPhoneNumberQuery = _mediator.Send(new UserByPhoneNumberQuery
        {
            Phone = "09906747192"
        });

        return resultUserByPhoneNumberQuery.Result.Match<bool>(
            r => true,
            exception => false);

    }

    public string VerifyPhone(string code, string phone)
    {
        var resultVerifyCode = _mediator.Send(new VerifyCodeQuery
        {
            Phone = phone,
            Code = code
        });

        return resultVerifyCode.Result.Match<string>(
            u => u.Token,
            exception => exception.Message);
    }
}