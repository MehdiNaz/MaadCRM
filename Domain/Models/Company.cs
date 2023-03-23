namespace Domain.Models;

public class Company
{
    public Company()
    {
        Koupons = new HashSet<Koupon>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Tel1 { get; set; }
    public string Tel2 { get; set; }
    public string Mobile { get; set; }
    public string WebSite { get; set; }
    public string Ceo { get; set; }
    public string CeoMobile { get; set; }
    public string Email { get; set; }
    public string BankName { get; set; }
    public string BankNo { get; set; }
    public string CardNo { get; set; }
    public string Makan { get; set; }
    public short? IdCity { get; set; }
    public string Pass { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }
    public string Lat { get; set; }
    public string Long { get; set; }
    public string UserName { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public decimal? Rate { get; set; }
    public string Description { get; set; }
    public int? CountKoupon { get; set; }
    public int? CountForoosh { get; set; }
    public decimal? MablaghForoosh { get; set; }
    public int? CountCancel { get; set; }
    public int? CountVisit { get; set; }
    public decimal? MablaghMande { get; set; }
    public string Token { get; set; }
    public string NotificationToken { get; set; }
    public string OneTimePass { get; set; }

    public virtual City IdCityNavigation { get; set; }
    public virtual ICollection<Koupon> Koupons { get; set; }
}