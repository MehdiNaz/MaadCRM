namespace Domain.Models.Customers;

public class CustomersPhoneNumber : BaseEntity
{
    public CustomersPhoneNumber()
    {
        Id = Ulid.NewUlid();
        StatusTypeCustomersPhoneNumber = StatusType.Show;
        PhoneType = PhoneTypes.Mobile;
    }

    public Ulid Id { get; set; }
    public required string PhoneNo { get; set; }
    public required PhoneTypes PhoneType { get; set; }
    public StatusType StatusTypeCustomersPhoneNumber { get; set; }

    
    public Ulid IdCustomer { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }
}