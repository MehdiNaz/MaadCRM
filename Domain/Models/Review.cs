namespace Domain.Models;

public class Review
{
    public int Id { get; set; }
    public string IdUser { get; set; }
    public int IdKoupon { get; set; }
    public byte Rate { get; set; }
    public string IpAddress { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual Koupon IdKouponNavigation { get; set; }
    // public virtual User1 IdUserNavigation { get; set; }
}