namespace Application.Services.Login.Commands;

public class SendSMSCommand : IRequest<bool>
{
    public required string Phone { get; set; }
}