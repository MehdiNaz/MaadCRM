namespace Domain.Models.Customers;

public class CustomerAddress : BaseEntity
{
    public CustomerAddress()
    {
        Id = Ulid.NewUlid();
        StatusCustomersAddress = Status.Show;
    }

    public Ulid Id { get; set; }
    public string Address { get; set; }
    public string? CodePost { get; set; }
    public string? PhoneNo { get; set; }
    public string? Description { get; set; }
    public Status StatusCustomersAddress { get; set; }

    
    public required Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    
    
    public byte[] RowVersion { get; set; }
}