namespace Application.Services.ContactPhoneNumberService.Commands;

public struct DeleteContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public Ulid ContactPhoneNumberId { get; set; }
}