namespace Application.Services.PhoneNumberService.Commands;

public class CreatePhoneNumberCommand : IRequest<PhoneNumber>
{
    public string PhoneNo { get; set; }
    public int PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }
}