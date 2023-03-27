namespace Domain.Models.Customers;

public class Moaref : BaseEntity
{
    public Moaref()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid MoarefId { get; set; }
    public string MoarefName { get; set; }
    public string MoarefFamily { get; set; }
    public string MoarefPhone { get; set; }
    public byte IsDeleted { get; set; }

    public ICollection<Customer> Customers { get; set; }
}