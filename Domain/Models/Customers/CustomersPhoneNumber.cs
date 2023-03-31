namespace Domain.Models.Customers;

public class CustomersPhoneNumber : BaseEntity
{
    public CustomersPhoneNumber()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }


    public Customer Customer { get; set; }
}