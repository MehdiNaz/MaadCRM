namespace Domain.Models.Address;

public class Province : BaseEntity
{
    public Ulid ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid CountryId { get; set; }
    //[ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }
    public ICollection<City> Cities { get; set; }
}