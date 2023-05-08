namespace Domain.Models.SpecialFields;

public class AttributeOptionValue : BaseEntity
{
    public AttributeOptionValue()
    {
        Id = Ulid.NewUlid();
        Status = Status.Show;
    }

    public Ulid Id { get; set; }
    public required string Value { get; set; }
    public string? FilePath { get; set; }
    public Status Status { get; set; }

    public Ulid? IdAttributeOption { get; set; }
    public AttributeOption? AttributeOptions { get; set; }
}