namespace Domain.Models.Payment;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Note { get; set; }
    public byte Status { get; set; }
    public string Mid { get; set; }
    public string RedirectUrl { get; set; }

    public virtual ICollection<Factor> Factors { get; set; }
}