namespace Application.Services.EmailAddressService.Commands;

public class UpdateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
    public string EmailAddrs { get; set; }
    public byte IsDeleted { get; set; }
}