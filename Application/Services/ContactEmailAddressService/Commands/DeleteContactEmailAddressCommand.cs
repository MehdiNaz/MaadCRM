namespace Application.Services.ContactEmailAddressService.Commands;

public class DeleteContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid CustomersEmailAddressId { get; set; }
}