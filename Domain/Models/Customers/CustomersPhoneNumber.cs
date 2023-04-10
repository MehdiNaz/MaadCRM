namespace Domain.Models.Customers;

public class CustomersPhoneNumber : BaseEntity
{
    public CustomersPhoneNumber()
    {
        PhoneNumberId = Ulid.NewUlid();
        CustomersPhoneNumberStatus = Status.Show;
        PhoneType = PhoneTypes.Mobile;
    }

    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomersPhoneNumberStatus { get; set; }


    // public Customer Customer { get; set; }
}