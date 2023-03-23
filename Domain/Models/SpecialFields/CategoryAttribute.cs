using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.General;

namespace Domain.Models.SpecialFields;

public class CategoryAttribute:BaseEntity
{
    /// <summary>
    /// salam
    /// </summary>
    public string Name { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public int BusinessId { get; set; }
    [ForeignKey(nameof(BusinessId))]
    public Business Business { get; set; }
    public ICollection<BusinessAttribute> BusinessAttributes { get; set; }
}