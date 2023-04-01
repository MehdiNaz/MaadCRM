namespace Domain.Models.Customers;

public class CustomerRepresentativeHistory : BaseEntity
{
    public CustomerRepresentativeHistory()
    {
        CustomerRepresentativeHistoryId = Ulid.NewUlid();
    }
    public Ulid CustomerRepresentativeHistoryId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomerRepresentativeTypeId { get; set; }
    //public int CustomerRepresentativeId { get; set; }

    //[ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    //[ForeignKey(nameof(CustomerRepresentativeId))]
    //public Customer CustomerRepresentative { get; set; }
    //[ForeignKey(nameof(CustomerRepresentativeTypeId))]
    public CustomerRepresentativeType CustomerRepresentativeType { get; set; }
}