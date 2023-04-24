namespace Domain.Models.Customers.Notes;

public class CustomerNote : BaseEntity
{
    public CustomerNote()
    {
        Id = Ulid.NewUlid();
        CustomerNoteStatus = Status.Show;
        NoteHashTags = new HashSet<CustomerNoteHashTag>();
        NoteAttachments = new HashSet<CustomerNoteAttachment>();
    }

    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Status CustomerNoteStatus { get; set; }

    public Ulid? IdProduct { get; set; }
    public virtual Product? IdProductNavigation { get; set; }

    public required Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }

    public required string IdUserUpdated { get; set; }
    public virtual User IdUserUpdateNavigation { get; set; }

    public string IdUserAdded { get; set; }
    public virtual User IdUserAddNavigation { get; set; }


    public virtual ICollection<CustomerNoteHashTag>? NoteHashTags { get; set; }
    public virtual ICollection<CustomerNoteAttachment>? NoteAttachments { get; set; }


    public uint Version { get; set; }
}