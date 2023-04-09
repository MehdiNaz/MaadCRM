namespace Domain.Models.Address;

public class Address : BaseEntity
{
    public Address()
    {
        AddressId = Ulid.NewUlid();
        AddressStatus = Status.Show;
    }

    public Ulid AddressId { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string CompanyName { get; set; }
    public string ZipPostalCode { get; set; }
    public string Description { get; set; }
    public Ulid CityId { get; set; }
    public Status AddressStatus { get; set; }


    //[ForeignKey(nameof(CustomerId))]
    //public Customer Customer { get; set; }

    //[ForeignKey(nameof(CityId))]
    public City City { get; set; }
}