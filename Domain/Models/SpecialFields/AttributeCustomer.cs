namespace Domain.Models.SpecialFields;

public class AttributeCustomer: BaseEntity
{
    public AttributeCustomer()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
    public string? ValueString { get; set; }
    public string? FilePath { get; set; }
    public bool? ValueBool { get; set; }
    public DateOnly? ValueDate { get; set; }
    public int? ValueNumber { get; set; }

    public Ulid? IdAttributeOption { get; set; }
    public AttributeOption? IdAttributeOptionNavigation { get; set; }

    public Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }
}
