namespace Domain.Models;

public class City
{
    public City()
    {
        Companies = new HashSet<Company>();
        Koupons = new HashSet<Koupon>();
        // Namayandes = new HashSet<Namayande>();
        Subscribes = new HashSet<Subscribe>();
        // User1s = new HashSet<User1>();
    }

    public short Id { get; set; }
    public string Name { get; set; }
    public byte IdProvince { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual Province IdProvinceNavigation { get; set; }
    public virtual ICollection<Company> Companies { get; set; }
    public virtual ICollection<Koupon> Koupons { get; set; }
    // public virtual ICollection<Namayande> Namayandes { get; set; }
    public virtual ICollection<Subscribe> Subscribes { get; set; }
    // public virtual ICollection<User1> User1s { get; set; }
}