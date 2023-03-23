namespace Domain.Models;

public class Visit
{
    public long Id { get; set; }
    public int IdKoupon { get; set; }
    public string IdUser { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual Koupon IdKouponNavigation { get; set; }
    // public virtual User1 IdUserNavigation { get; set; }
}