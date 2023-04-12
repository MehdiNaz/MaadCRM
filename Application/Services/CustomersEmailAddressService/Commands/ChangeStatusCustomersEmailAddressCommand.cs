namespace Application.Services.CustomersEmailAddressService.Commands;

public struct ChangeStatusCustomersEmailAddressCommand : IRequest<CustomersEmailAddress?>
{
    public Ulid CustomersEmailAddressId { get; set; }
    public Status ContactsEmailAddressStatus { get; set; }
}