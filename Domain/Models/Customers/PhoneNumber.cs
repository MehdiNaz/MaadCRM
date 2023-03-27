namespace Domain.Models.Customers;

public class PhoneNumber : BaseEntity
{
    public PhoneNumber()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public int PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }


    //[ForeignKey(nameof(CustomerId))]

    public Customer Customer { get; set; }
}