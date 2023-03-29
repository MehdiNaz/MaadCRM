namespace Application.Services.ContactPhoneNumberService.Commands;

public struct UpdateContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public Ulid ContactPhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }
}