namespace Application.Services.ContactEmailAddressService.Commands;

public struct ChangeStatusContactEmailAddressCommand : IRequest<ContactsEmailAddress?>
{
    public Ulid CustomersEmailAddressId { get; set; }
    public StatusType ContactsEmailAddressStatusType { get; set; }
}