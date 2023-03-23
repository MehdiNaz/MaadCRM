namespace Domain.Models;

public class SendType
{
    public SendType()
    {
        Factors = new HashSet<Factor>();
        Koupons = new HashSet<Koupon>();
    }

    public int Id { get; set; }
    public string Txt { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual ICollection<Factor> Factors { get; set; }
    public virtual ICollection<Koupon> Koupons { get; set; }
}