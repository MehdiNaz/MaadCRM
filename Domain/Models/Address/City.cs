namespace Domain.Models.Address;

public class City : BaseEntity
{
    public City()
    {
        CityId = Ulid.NewUlid();
    }
    public Ulid CityId { get; set; }
    public string CityName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid ProvinceId { get; set; }
    public Ulid CustomerId { get; set; }




    //[ForeignKey(nameof(ProvinceId))]
    public Province Province { get; set; }

    public ICollection<Address> Addresses { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Customer> Customers { get; set; }

}