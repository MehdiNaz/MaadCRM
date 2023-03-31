namespace Domain.Models.Address;

public class Address : BaseEntity
{
    public Ulid AddressId { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string CompanyName { get; set; }
    public string ZipPostalCode { get; set; }
    public string Description { get; set; }
    //public Ulid CustomerId { get; set; }
    public int CityId { get; set; }


    //[ForeignKey(nameof(CustomerId))]
    //public Customer Customer { get; set; }

    //[ForeignKey(nameof(CityId))]
    public City City { get; set; }
}