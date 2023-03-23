using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.General;

public class Province:BaseEntity
{
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public int CountryId { get; set; }
    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }
    public ICollection<City> Cities { get; set; }
}