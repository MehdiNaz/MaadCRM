namespace Domain.Models.Customers;

public class CustomerRepresentativeHistory:BaseEntity
{
    public int CustomerId { get; set; }
    public int CustomerRepresentativeTypeId { get; set; }
    public int CustomerRepresentativeId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    [ForeignKey(nameof(CustomerRepresentativeId))]
    public Customer CustomerRepresentative { get; set; }
    [ForeignKey(nameof(CustomerRepresentativeTypeId))]
    public CustomerRepresentativeType CustomerRepresentativeType { get; set; }

}