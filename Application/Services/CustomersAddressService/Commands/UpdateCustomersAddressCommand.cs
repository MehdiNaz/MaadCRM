namespace Application.Services.CustomersAddressService.Commands;

public struct UpdateCustomersAddressCommand: IRequest<CustomerAddress>
{
    public Ulid Id { get; set; }
    public string Address { get; set; }
    public string? CodePost { get; set; }
    public string? PhoneNo { get; set; }
    public string? Description { get; set; }
    public Ulid CustomerId { get; set; }
}