namespace Application.Services.CustomersEmailAddressService.Commands;

public struct ChangeStatusCustomersEmailAddressCommand : IRequest<CustomersEmailAddress?>
{
    public Ulid Id { get; set; }
    public Status ContactsEmailAddressStatus { get; set; }
}