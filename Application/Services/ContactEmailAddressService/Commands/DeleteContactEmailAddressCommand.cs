namespace Application.Services.ContactEmailAddressService.Commands;

public struct DeleteContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid CustomersEmailAddressId { get; set; }
}