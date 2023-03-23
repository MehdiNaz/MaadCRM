using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Customers;

namespace Domain.Models.General;

public class Address:BaseEntity
{
    public int CityId { get; set; }
    public string Address1 { get; set; }
    public string address2 { get; set; }
    public string CompanyName { get; set; }
    public string ZipPostalCode { get; set; }
    public string Description { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

    [ForeignKey(nameof(CityId))]
    public City city { get; set; }
}