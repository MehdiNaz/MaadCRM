namespace Application.Services.ContactPhoneNumberService.Commands;

public class CreateContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
}