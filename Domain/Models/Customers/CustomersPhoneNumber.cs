namespace Domain.Models.Customers;

public class CustomersPhoneNumber : BaseEntity
{
    public CustomersPhoneNumber()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public int PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }


    //[ForeignKey(nameof(CustomerId))]

    public ICollection<Customer> Customers { get; set; }
}