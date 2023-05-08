namespace Domain.Models.SpecialFields;

public class Attribute : BaseEntityWithUserUpdate
{
    public Attribute()
    {
        Id = Ulid.NewUlid();
        AttributeOptionsStatus = Status.Show;
        DisplayOrder = 0;
        IsRequired = false;
    }

    public Ulid Id { get; set; }
    public string Lable { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsRequired { get; set; }

    public required AttributeInputType AttributeInputTypeId { get; set; }
    public required AttributeType AttributeTypeId { get; set; }

    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtension { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string? DefaultValue { get; set; }

    public Ulid? IdBusiness { get; set; }
    public Business? IdBusinessNavigation { get; set; }
    public Status AttributeOptionsStatus { get; set; }
}