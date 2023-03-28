namespace Application.Services.EmailAddressService.Commands;

public class DeleteCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
}