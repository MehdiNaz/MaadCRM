namespace Application.Services.ContactPhoneNumberService.Commands;

public struct CreateContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
}