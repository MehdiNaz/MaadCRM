namespace Domain.Models.SpecialFields;

public class AttributeOptions:BaseEntity
{
    public string Name { get; set; }
    public string ColorSquaresRgb { get; set; }
    public int BusinessAttributeId { get; set; }
    public int? ImageSequrePictureId { get; set; }
    public int DisplayOrder { get; set; } = 0;

    [ForeignKey(nameof(BusinessAttributeId))]
    public BusinessAttribute BusinessAttribute { get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
}