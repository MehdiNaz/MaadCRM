namespace Application.Services.CustomersEmailAddressService.Queries;

public struct GetCustomersEmailAddressesByIdQuery : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
}