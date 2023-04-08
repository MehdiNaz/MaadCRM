namespace Domain.Models.SpecialFields;

public class BusinessAttribute : BaseEntity
{
    public BusinessAttribute()
    {
        BusinessAttributeId = Ulid.NewUlid();
        BusinessAttributeStatus = Status.Show;
    }

    public Ulid BusinessAttributeId { get; set; }
    public string TextPrompt { get; set; }
    public bool IsRequired { get; set; }
    public AttributeType AttributeTypeId { get; set; }
    public int DisplayOrder { get; set; }
    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtention { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string DefaultValue { get; set; }
    public string ConditionValue { get; set; }
    public Ulid CategoryAttributeId { get; set; }
    public Status BusinessAttributeStatus { get; set; }


    public ICollection<Business>? Businesses { get; set; }
    public CategoryAttribute CategoryAttribute { get; set; }
    public ICollection<AttributeOptions>? AttributeOptions { get; set; }
}