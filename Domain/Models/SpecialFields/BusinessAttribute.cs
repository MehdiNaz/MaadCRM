namespace Domain.Models.SpecialFields;

public class BusinessAttribute : BaseEntity
{
    public Ulid BusinessAttributeId { get; set; }
    public string TextPrompt { get; set; }
    public bool IsRequired { get; set; }
    public AttributeControlType AttributeControlTypeId { get; set; }
    public int DisplayOrder { get; set; }
    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtention { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string DefaultValue { get; set; }
    public string ConditionValue { get; set; }
    public Ulid CategoryAttributeId { get; set; }

    //[ForeignKey(nameof(CategoryAttributeId))]
    public CategoryAttribute CategoryAttribute { get; set; }
    public ICollection<AttributeOptions> AttributeOptions { get; set; }
}