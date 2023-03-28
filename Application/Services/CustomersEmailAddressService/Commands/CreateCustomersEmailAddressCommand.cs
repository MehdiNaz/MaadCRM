namespace Application.Services.EmailAddressService.Commands;

public class CreateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public string EmailAddrs { get; set; }
    public byte IsDeleted { get; set; }
}