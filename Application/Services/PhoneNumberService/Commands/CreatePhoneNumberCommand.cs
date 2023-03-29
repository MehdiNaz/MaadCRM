namespace Application.Services.PhoneNumberService.Commands;

public struct CreatePhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
}