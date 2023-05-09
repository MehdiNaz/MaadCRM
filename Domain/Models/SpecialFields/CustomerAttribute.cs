namespace Domain.Models.SpecialFields;

public class CustomerAttribute
{
    public CustomerAttribute()
    {
        Id = Ulid.NewUlid();
        StatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public StatusType StatusType { get; set; }

    public Ulid? IdAttributeOption { get; set; }
    public AttributeOption? IdAttributeOptionNavigation { get; set; }

    public Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

}



    

