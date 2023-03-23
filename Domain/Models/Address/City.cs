using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.General;

public class City:BaseEntity
{
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public int ProvinceId { get; set; }
    [ForeignKey(nameof(ProvinceId))]
    public Province Province { get; set; }
    public ICollection<Address> Addresses { get; set; }
}