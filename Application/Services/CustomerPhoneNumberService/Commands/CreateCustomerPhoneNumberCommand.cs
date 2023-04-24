namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct CreateCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
    public string? IdUser { get; set; }
}