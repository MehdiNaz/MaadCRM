namespace Domain.Models.Customers;

public class CustomerAddress : BaseEntity
{
    public CustomerAddress()
    {
        Id = Ulid.NewUlid();
        StatusCustomersAddress = Status.Show;
        ForooshFactors = new HashSet<ForooshFactor>();
    }

    public Ulid Id { get; set; }
    public string Address { get; set; }
    public string? CodePost { get; set; }
    public string? PhoneNo { get; set; }
    public string? Description { get; set; }
    public Status StatusCustomersAddress { get; set; }

    
    public required Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }
    
    public virtual ICollection<ForooshFactor>? ForooshFactors { get; set; }
}