namespace Domain.Models.Customers;

public class Moaref : BaseEntity
{
    public Moaref()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid MoarefId { get; set; }
    public string MoarefName { get; set; }
    public string MoarefFamily { get; set; }
    public string MoarefPhone { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Customer> Customers { get; set; }
}