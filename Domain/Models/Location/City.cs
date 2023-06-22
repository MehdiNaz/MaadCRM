namespace Domain.Models.Location;

public class City : BaseEntity
{
    public City()
    {
        Id = Ulid.NewUlid();
        CityStatusType = StatusType.Show;
        Customers = new HashSet<Customer>();
    }

    public Ulid Id { get; set; }
    public string CityName { get; set; }
    public bool IsDefault { get; set; }
    public uint DisplayOrder { get; set; }
    public Ulid IdProvince { get; set; }
    public StatusType CityStatusType { get; set; }


    public virtual Province IdProvinceNavigation { get; set; }

    // public ICollection<Address>? Addresses { get; set; }
    public ICollection<User>? Users { get; set; }
    public virtual ICollection<Customer>? Customers { get; set; }

}