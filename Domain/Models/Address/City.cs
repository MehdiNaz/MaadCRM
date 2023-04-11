namespace Domain.Models.Address;

public class City : BaseEntity
{
    public City()
    {
        CityId = Ulid.NewUlid();
        CityStatus = Status.Show;
    }

    public Ulid CityId { get; set; }
    public string CityName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid ProvinceId { get; set; }
    //public Ulid Id { get; set; }
    public Status CityStatus { get; set; }




    // public Province Province { get; set; }

    public ICollection<Address>? Addresses { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Customer>? Customers { get; set; }

}