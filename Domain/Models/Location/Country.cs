namespace Domain.Models.Location;

public class Country : BaseEntity
{
    public Country()
    {
        Id = Ulid.NewUlid();
        CountryStatus = Status.Show;
        Provinces = new HashSet<Province>();
    }

    public Ulid Id { get; set; }
    public string CountryName { get; set; }
    public bool IsDefault { get; set; }
    public uint DisplayOrder { get; set; }
    public Status CountryStatus { get; set; }
    
    public virtual ICollection<Province>? Provinces { get; set; }
}