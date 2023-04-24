namespace Application.Services.CustomersAddressService.Commands;

public struct CreateCustomersAddressCommand : IRequest<CustomerAddress>
{
    public string Address { get; set; }
    public string? CodePost { get; set; }
    public string? PhoneNo { get; set; }
    public string? Description { get; set; }
    public Ulid CustomerId { get; set; }
    public string? IdUser { get; set; }
}