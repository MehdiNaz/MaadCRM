namespace Domain.Models;

public class Company:BaseEntity
{
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
    public string Lat { get; set; }
    public string Long { get; set; }
    public string UserName { get; set; }
    public decimal? Rate { get; set; }
    public string Description { get; set; }

    // public virtual ICollection<Koupon> Koupons { get; set; }
}