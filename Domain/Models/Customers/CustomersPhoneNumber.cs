namespace Domain.Models.Customers;

public class CustomersPhoneNumber : BaseEntity
{
    public CustomersPhoneNumber()
    {
        Id = Ulid.NewUlid();
        StatusCustomersPhoneNumber = Status.Show;
        PhoneType = PhoneTypes.Mobile;
    }

    public Ulid Id { get; set; }
    public required string PhoneNo { get; set; }
    public required PhoneTypes PhoneType { get; set; }
    public Status StatusCustomersPhoneNumber { get; set; }

    
    public Ulid IdCustomer { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }
    
    public uint RowVersion { get; set; }
}