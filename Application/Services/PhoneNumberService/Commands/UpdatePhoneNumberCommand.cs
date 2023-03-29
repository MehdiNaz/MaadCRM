namespace Application.Services.PhoneNumberService.Commands;

public struct UpdatePhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
}