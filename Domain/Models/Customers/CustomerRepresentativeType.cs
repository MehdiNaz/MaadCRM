namespace Domain.Models.Customers;

public class CustomerRepresentativeType : BaseEntity
{
    public int CustomerRepresentativeName { get; set; }
    public int DisplayOrder { get; set; }
    public decimal Point { get; set; }
    public int BalancePoint { get; set; }
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory { get; set; }
}