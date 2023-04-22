namespace Domain.Models.Address;

public class Country : BaseEntity
{
    public Country()
    {
        Id = Ulid.NewUlid();
        StatusCountry = Status.Show;
        Provinces = new HashSet<Province>();
    }

    public Ulid Id { get; set; }
    public string CountryName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Status StatusCountry { get; set; }
    
    public virtual ICollection<Province>? Provinces { get; set; }
}