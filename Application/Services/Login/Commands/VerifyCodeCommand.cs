using MediatR;

namespace Application.Services.Login.Commands;

public class SendVerifyCommand:IRequest<bool>
{
    public required string Phone { get; set; }
}