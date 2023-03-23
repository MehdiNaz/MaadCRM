namespace Domain.Models;

public class Province
{
    public Province()
    {
        Cities = new HashSet<City>();
    }

    public byte Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual ICollection<City> Cities { get; set; }
}