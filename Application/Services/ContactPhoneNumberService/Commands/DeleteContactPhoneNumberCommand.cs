namespace Application.Services.ContactPhoneNumberService.Commands;

public struct DeleteContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public Ulid Id { get; set; }
}