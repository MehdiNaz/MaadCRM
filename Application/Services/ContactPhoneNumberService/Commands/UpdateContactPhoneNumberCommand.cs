namespace Application.Services.ContactPhoneNumberService.Commands;

public struct UpdateContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public Ulid Id { get; set; }
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
}