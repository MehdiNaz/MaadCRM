namespace Domain.Models;

public partial class Order
{
    public int Id { get; set; }
    public int IdFactor { get; set; }
    public int IdKoupon { get; set; }
    public string IpAddress { get; set; }
    public int? IdCode { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }
    public decimal? Price { get; set; }
    public decimal? PriceFinal { get; set; }

    public virtual Factor IdFactorNavigation { get; set; }
    public virtual Koupon IdKouponNavigation { get; set; }
}