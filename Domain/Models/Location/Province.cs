namespace Domain.Models.Location;

public class Province : BaseEntity
{
    public Province()
    {
        Id = Ulid.NewUlid();
        ProvinceStatusType = StatusType.Show;
        Cities = new HashSet<City>();
    }

    public Ulid Id { get; set; }
    public string ProvinceName { get; set; }
    public bool IsDefault { get; set; }
    public uint DisplayOrder { get; set; }
    public StatusType ProvinceStatusType { get; set; }


    public Ulid IdCountry { get; set; }
    public virtual Country IdCountryNavigation { get; set; }
    public virtual ICollection<City>? Cities { get; set; }
}