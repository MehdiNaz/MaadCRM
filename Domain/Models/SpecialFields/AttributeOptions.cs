namespace Domain.Models.SpecialFields;

public class AttributeOptions : BaseEntity
{
    public Ulid AttributeOptionsId { get; set; }
    public string Name { get; set; }
    public string ColorSquaresRgb { get; set; }
    public Ulid BusinessAttributeId { get; set; }
    public int? ImageSequrePictureId { get; set; }
    public int DisplayOrder { get; set; } = 0;

    //[ForeignKey(nameof(BusinessAttributeId))]
    public BusinessAttribute BusinessAttribute { get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
}