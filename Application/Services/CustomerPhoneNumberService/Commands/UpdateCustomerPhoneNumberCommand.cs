namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct UpdateCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
}