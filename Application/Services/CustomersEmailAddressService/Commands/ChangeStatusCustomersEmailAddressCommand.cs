namespace Application.Services.CustomersEmailAddressService.Commands;

public struct ChangeStatusCustomersEmailAddressCommand : IRequest<CustomersEmailAddress?>
{
    public Ulid Id { get; set; }
    public StatusType ContactsEmailAddressStatusType { get; set; }
}