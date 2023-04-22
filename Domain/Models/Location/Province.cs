namespace Domain.Models.Address;

public class Province : BaseEntity
{
    public Province()
    {
        Id = Ulid.NewUlid();
        StatusProvince = Status.Show;
        Cities = new HashSet<City>();
    }

    public Ulid Id { get; set; }
    public string ProvinceName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Status StatusProvince { get; set; }


    public Ulid IdCountry { get; set; }
    public virtual Country IdCountryNavigation { get; set; }
    public virtual ICollection<City>? Cities { get; set; }
}