namespace Application.Services.ContactPhoneNumberService.Commands;

public struct ChangeStatusContactPhoneNumberCommand : IRequest<ContactPhoneNumber?>
{
    public Ulid ContactPhoneNumberId { get; set; }
    public Status ContactPhoneNumberStatus { get; set; }
}