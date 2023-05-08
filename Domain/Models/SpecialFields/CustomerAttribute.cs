namespace Domain.Models.SpecialFields;

public class CustomerAttribute
{
    public CustomerAttribute()
    {
        Id = Ulid.NewUlid();
        Status = Status.Show;
    }

    public Ulid Id { get; set; }
    public Status Status { get; set; }

    public Ulid? IdAttributeOption { get; set; }
    public AttributeOption? IdAttributeOptionNavigation { get; set; }

    public Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

}



    

