namespace Application.Services.ContactPhoneNumberService.Commands;

public struct ChangeStatusContactPhoneNumberCommand : IRequest<ContactPhoneNumber?>
{
    public Ulid ContactPhoneNumberId { get; set; }
    public StatusType ContactPhoneNumberStatusType { get; set; }
}