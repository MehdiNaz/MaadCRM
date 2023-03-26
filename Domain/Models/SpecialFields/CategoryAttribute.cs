namespace Domain.Models.SpecialFields;

public class CategoryAttribute : BaseEntity
{
    /// <summary>
    /// salam
    /// </summary>
    public Ulid CategoryAttributeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public Ulid BusinessId { get; set; }
    
    
    //[ForeignKey(nameof(BusinessId))]
    public Business Business { get; set; }
    public ICollection<BusinessAttribute> BusinessAttributes { get; set; }
}