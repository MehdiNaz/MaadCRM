namespace Domain.Models.Address;

public class Country : BaseEntity
{
    public Country()
    {
        CountryId = Ulid.NewUlid();
    }

    public Ulid CountryId { get; set; }
    public string CountryName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<Province> Provinces { get; set; }
}