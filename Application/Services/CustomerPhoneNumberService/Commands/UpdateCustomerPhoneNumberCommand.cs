namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct UpdateCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid Id { get; set; }
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
}