namespace Domain.Models;

public partial class PaymentMethod
{
    public PaymentMethod()
    {
        Factors = new HashSet<Factor>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Note { get; set; }
    public byte Status { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }
    public string Mid { get; set; }
    public string RedirectUrl { get; set; }

    public virtual ICollection<Factor> Factors { get; set; }
}