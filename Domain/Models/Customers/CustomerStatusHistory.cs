namespace Domain.Models.Customers;

public class CustomerStatusHistory : BaseEntity
{
    public int CustomerId { get; set; }
    public int CustomerStatusId { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    //[ForeignKey(nameof(CustomerStatusId))]
    //public CustomerActivationStatus CustomerActivationStatus { get; set; }
}