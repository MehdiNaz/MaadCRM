namespace Application.Services.EmailAddressService.Query;

public class GetCustomersEmailAddressesByIdQuery : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
}